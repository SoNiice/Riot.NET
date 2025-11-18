using System;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Riot.NET.Generator;

[Generator]
public class EndpointGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new MethodSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var receiver = (MethodSyntaxReceiver)context.SyntaxReceiver;

        if (receiver == null || receiver.MethodClasses.Count == 0)
            return;

        var methodsByNamespace = receiver.MethodClasses
            .Select(methodClass =>
            {
                var semanticModel = context.Compilation.GetSemanticModel(methodClass.SyntaxTree);
                var typeSymbol = semanticModel.GetDeclaredSymbol(methodClass) as INamedTypeSymbol;
                return new { MethodClass = methodClass, TypeSymbol = typeSymbol };
            })
            .Where(item => item.TypeSymbol != null)
            .GroupBy(item => GetEndpointNamespace(GetNamespace(item.MethodClass)))
            .Where(group => !string.IsNullOrEmpty(group.Key));

        foreach (var group in methodsByNamespace)
        {
            var endpointNamespace = group.Key;
            var endpointClassName = GetEndpointClassName(endpointNamespace);

            if (string.IsNullOrEmpty(endpointClassName))
                continue;

            var sourceBuilder = new StringBuilder($@"using System;
using System.Threading.Tasks;
using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Extensions;
using {endpointNamespace}.Methods;
using {endpointNamespace}.Responses;

namespace {endpointNamespace}
{{
    public partial class {endpointClassName}
    {{");

            foreach (var item in group)
            {
                var methodClass = item.MethodClass;
                var typeSymbol = item.TypeSymbol;

                var implementsIMethod = false;
                ITypeSymbol responseTypeSymbol = null;
                var isRegionBased = false;
                var isShardBased = false;
                var isAccessTokenBased = false;
                var isRegionAccessTokenBased = false;
                var isDataDragonDataBased = false;
                var isDataDragonFilteredDataBased = false;
                var isValorantApiDataBased = false;
                var isValorantApiFilteredDataBased = false;

                foreach (var @interface in typeSymbol.AllInterfaces.Where(@interface => @interface.Name == "IMethod" && @interface.IsGenericType && @interface.TypeArguments.Length == 1))
                {
                    implementsIMethod = true;
                    responseTypeSymbol = @interface.TypeArguments[0];
                    break;
                }

                if (!implementsIMethod)
                    continue;

                var currentType = typeSymbol.BaseType;
                while (currentType != null)
                {
                    if (currentType.Name.Contains("MethodBase") && currentType.IsGenericType && (currentType.TypeArguments.Length == 1 || currentType.TypeArguments.Length == 2))
                    {
                        implementsIMethod = true;
                        responseTypeSymbol = currentType.TypeArguments[0];

                        if (currentType.Name.Contains("StaticShardAccessTokenMethodBase"))
                            isAccessTokenBased = true;
                        else if (currentType.Name.Contains("RegionAccessTokenMethodBase"))
                            isRegionAccessTokenBased = true;
                        else if (currentType.Name.Contains("RegionMethodBase"))
                            isRegionBased = true;
                        else if (currentType.Name.Contains("ShardMethodBase") && !currentType.Name.Contains("StaticShardMethodBase"))
                            isShardBased = true;
                        else if (currentType.Name.Contains("DataDragonFilteredDataMethodBase"))
                        {
                            responseTypeSymbol = currentType.TypeArguments[1];
                            isDataDragonFilteredDataBased = true;
                        }
                        else if (currentType.Name.Contains("DataDragonDataMethodBase"))
                            isDataDragonDataBased = true;
                        else if (currentType.Name.Contains("ValorantApiFilteredDataMethodBase"))
                        {
                            responseTypeSymbol = currentType.TypeArguments[1];
                            isValorantApiFilteredDataBased = true;
                        }
                        else if (currentType.Name.Contains("ValorantApiDataMethodBase"))
                            isValorantApiDataBased = true;

                        break;
                    }

                    currentType = currentType.BaseType;
                }

                var methodNamespace = GetNamespace(methodClass);
                var className = methodClass.Identifier.Text;

                var methodParameters = typeSymbol.GetMembers()
                    .Where(m => m.Kind == SymbolKind.Property)
                    .Cast<IPropertySymbol>()
                    .Where(p => HasRequestParameterAttribute(p) || HasBodyParameterAttribute(p))
                    .ToList();

                var parameters = new StringBuilder();
                var argumentsList = new StringBuilder();
                var firstParam = true;

                var summaryAttribute = typeSymbol.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "SummaryAttribute");
                var methodSummary = string.Empty;
                var returnsSummary = string.Empty;

                if (summaryAttribute != null)
                {
                    if (summaryAttribute.ConstructorArguments.Length > 0)
                        methodSummary = summaryAttribute.ConstructorArguments[0].Value?.ToString() ?? string.Empty;

                    if (summaryAttribute.ConstructorArguments.Length > 1)
                        returnsSummary = summaryAttribute.ConstructorArguments[1].Value?.ToString() ?? string.Empty;
                }

                var xmlDoc = new StringBuilder();
                xmlDoc.AppendLine("        /// <summary>");

                if (!string.IsNullOrEmpty(methodSummary))
                    xmlDoc.AppendLine($"        /// {methodSummary}");

                xmlDoc.AppendLine("        /// </summary>");
                
                if (isRegionAccessTokenBased)
                {
                    parameters.Append("Region region");
                    parameters.Append(", ");
                    parameters.Append("string accessToken");
                    argumentsList.Append("Region = region");
                    argumentsList.Append(@",
                ");
                    argumentsList.Append("AccessToken = accessToken");
                    firstParam = false;
                    xmlDoc.AppendLine("        /// <param name=\"accessToken\">A users access token obtained by OAuth</param>");
                }

                if (isAccessTokenBased)
                {
                    parameters.Append("string accessToken");
                    argumentsList.Append("AccessToken = accessToken");
                    firstParam = false;
                    xmlDoc.AppendLine("        /// <param name=\"accessToken\">A users access token obtained by OAuth</param>");
                }

                if (isRegionBased)
                {
                    parameters.Append("Region region");
                    argumentsList.Append("Region = region");
                    firstParam = false;
                    xmlDoc.AppendLine("        /// <param name=\"region\"><see cref=\"Region\"/> corresponding to the endpoint's request</param>");
                }

                if (isShardBased)
                {
                    parameters.Append("Shard shard");
                    argumentsList.Append("Shard = shard");
                    firstParam = false;
                    xmlDoc.AppendLine("        /// <param name=\"shard\"><see cref=\"Shard\"/> corresponding to the endpoint's request</param>");
                }

                var format = new SymbolDisplayFormat(
                    typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly,
                    genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                    miscellaneousOptions: SymbolDisplayMiscellaneousOptions.None);

                foreach (var prop in methodParameters)
                {
                    var paramName = char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1);

                    if (!firstParam)
                    {
                        parameters.Append(", ");
                        argumentsList.Append(@",
                ");
                    }

                    firstParam = false;

                    var paramType = prop.Type.ToDisplayString(format);

                    if (paramType == "MatchType")
                        paramType = "Riot.NET.Enums.MatchType";

                    if (paramType == "MatchType?")
                        paramType = "Riot.NET.Enums.MatchType?";

                    var defaultValueAttr = prop.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "DefaultValueAttribute");

                    if (defaultValueAttr != null)
                    {
                        var defaultValue = defaultValueAttr.ConstructorArguments.FirstOrDefault().Value;
                        var defaultValueStr = FormatDefaultValue(defaultValue, prop.Type);

                        if (paramType == "DateTime" && defaultValueStr == "0")
                            defaultValueStr = "default";

                        parameters.Append($"{paramType} {paramName} = {defaultValueStr}");
                    }
                    else
                        parameters.Append($"{paramType} {paramName}");

                    argumentsList.Append($"{prop.ToDisplayString(format)} = {paramName}");

                    var requestParamAttr = prop.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "RequestParameterAttribute");
                    var paramDescription = string.Empty;

                    if (requestParamAttr != null && requestParamAttr.ConstructorArguments.Length > 1)
                        paramDescription = requestParamAttr.ConstructorArguments[1].Value?.ToString() ?? string.Empty;

                    if (string.IsNullOrEmpty(paramDescription))
                        xmlDoc.AppendLine($"        /// <param name=\"{paramName}\"></param>");
                    else
                        xmlDoc.AppendLine($"        /// <param name=\"{paramName}\">{paramDescription}</param>");

                    // var bodyParamAttr = prop.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "BodyParameterAttribute");
                    // var bodyParamDescription = string.Empty;
                    //
                    // if (bodyParamAttr != null && bodyParamAttr.ConstructorArguments.Length > 1)
                    //     bodyParamDescription = requestParamAttr.ConstructorArguments[1].Value?.ToString() ?? string.Empty;
                    //
                    // if (string.IsNullOrEmpty(bodyParamDescription))
                    //     xmlDoc.AppendLine($"        /// <param name=\"{paramName}\"></param>");
                    // else
                    //     xmlDoc.AppendLine($"        /// <param name=\"{paramName}\">{bodyParamDescription}</param>");
                }

                if (isDataDragonDataBased || isDataDragonFilteredDataBased)
                {
                    if (!firstParam)
                    {
                        parameters.Append(", ");
                        argumentsList.Append(@",
                ");
                    }

                    parameters.Append("string version");
                    parameters.Append(", ");
                    parameters.Append("string language = \"en_US\"");
                    argumentsList.Append("Version = version");
                    argumentsList.Append(@",
                ");
                    argumentsList.Append("Language = language");
                    firstParam = false;
                    xmlDoc.AppendLine("        /// <param name=\"version\"><see cref=\"string\"/> corresponding to the endpoint's request</param>");
                    xmlDoc.AppendLine("        /// <param name=\"language\"><see cref=\"string\"/> corresponding to the endpoint's request</param>");
                }

                if (isValorantApiDataBased || isValorantApiFilteredDataBased)
                {
                    if (!firstParam)
                    {
                        parameters.Append(", ");
                        argumentsList.Append(@",
                ");
                    }

                    parameters.Append("string language = \"en_US\"");
                    argumentsList.Append("Language = language");
                    firstParam = false;
                    xmlDoc.AppendLine("        /// <param name=\"language\"><see cref=\"string\"/> corresponding to the endpoint's request</param>");
                }

                var responseTypeName = responseTypeSymbol.ToDisplayString(format);

                if (string.IsNullOrEmpty(returnsSummary))
                {
                    if (responseTypeSymbol is INamedTypeSymbol { IsGenericType: true } namedResponseType)
                    {
                        var collectionTypeName = namedResponseType.Name;
                        var itemTypeName = namedResponseType.TypeArguments[0].ToDisplayString(format);

                        returnsSummary = $"A <see cref=\"{collectionTypeName}\"/> of <see cref=\"{itemTypeName}\"/>.";
                    }
                    else
                    {
                        var article = "aeiou".IndexOf(char.ToLower(responseTypeName[0])) >= 0 ? "An" : "A";
                        returnsSummary = $"{article} <see cref=\"{responseTypeName}\"/>.";
                    }
                }

                xmlDoc.AppendLine($"        /// <returns>{returnsSummary}</returns>");

                var executeMethod = isDataDragonFilteredDataBased || isValorantApiFilteredDataBased ? "ExecuteWithFilter" : "Execute";

                // context.ReportDiagnostic(Diagnostic.Create(
                //     new DiagnosticDescriptor(
                //         "GEN002",
                //         "Parameterless constructor required",
                //         executeMethod,
                //         "SourceGenerator",
                //         DiagnosticSeverity.Warning,
                //         isEnabledByDefault: true),
                //     item.MethodClass.GetLocation()));

                sourceBuilder.AppendLine($@"
        private {className} _{className.Substring(0, 1).ToLower() + className.Substring(1)} = new {className}(typeof({endpointClassName}).GetEndpoint(), rateLimiter);
{xmlDoc}        public Task<{responseTypeName}> {className}Async({parameters})
        {{
            var method = new {className}(typeof({endpointClassName}).GetEndpoint(), rateLimiter)
            {{
                {argumentsList}
            }};
            return method.{executeMethod}Async();
        }}");

                sourceBuilder.AppendLine($@"
{xmlDoc}        public {responseTypeName} {className}({parameters})
        {{
            var method = new {className}(typeof({endpointClassName}).GetEndpoint(), rateLimiter)
            {{
                {argumentsList}
            }};
            return method.{executeMethod}();
        }}");
            }

            sourceBuilder.AppendLine(@"
    }
}");

            context.AddSource($"{endpointClassName}.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }
    }

    private bool HasRequestParameterAttribute(IPropertySymbol property)
    {
        return property.GetAttributes().Any(attr => attr.AttributeClass?.Name == "RequestParameterAttribute");
    }

    private bool HasBodyParameterAttribute(IPropertySymbol property)
    {
        return property.GetAttributes().Any(attr => attr.AttributeClass?.Name == "BodyParameterAttribute");
    }

    private string FormatDefaultValue(object value, ITypeSymbol type)
    {
        if (value == null)
            return "null";

        if (type.SpecialType == SpecialType.System_String)
            return $"\"{value}\"";

        if (type.SpecialType == SpecialType.System_Boolean)
            return value.ToString().ToLowerInvariant();

        if (type.TypeKind == TypeKind.Enum)
        {
            var enumType = (INamedTypeSymbol)type;
            var numericValue = Convert.ToInt64(value);

            foreach (var member in enumType.GetMembers().OfType<IFieldSymbol>())
            {
                if (member.HasConstantValue && Convert.ToInt64(member.ConstantValue) == numericValue)
                    return $"{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}.{member.Name}";
            }

            return $"{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}.{value}";
        }

        return value.ToString();
    }

    private string GetNamespace(ClassDeclarationSyntax classDeclaration)
    {
        return classDeclaration.Parent switch
        {
            NamespaceDeclarationSyntax namespaceDeclaration => namespaceDeclaration.Name.ToString(),
            FileScopedNamespaceDeclarationSyntax fileScopedNamespace => fileScopedNamespace.Name.ToString(),
            _ => string.Empty
        };
    }

    private string GetEndpointNamespace(string methodNamespace)
    {
        return methodNamespace.EndsWith(".Methods") ? methodNamespace.Substring(0, methodNamespace.Length - ".Methods".Length) : string.Empty;
    }

    private string GetEndpointClassName(string endpointNamespace)
    {
        var parts = endpointNamespace.Split('.');
        return parts.Length > 0 ? parts[parts.Length - 1] : string.Empty;
    }
}