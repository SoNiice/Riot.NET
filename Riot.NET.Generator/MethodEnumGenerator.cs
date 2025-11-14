using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Riot.NET.Generator;

[Generator]
public class MethodEnumGenerator : ISourceGenerator
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
            .Where(item => item.TypeSymbol != null && ImplementsIMethod(item.TypeSymbol))
            .ToList();

        if (methodsByNamespace.Count == 0)
            return;

        var sourceBuilder = new StringBuilder(@"using System;
using System.Collections.Generic;
using Riot.NET.Attributes;
using Riot.NET.Enums;

namespace Riot.NET.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EndpointPathAttribute : Attribute
    {
        public string Path { get; }

        public EndpointPathAttribute(string path)
        {
            Path = path;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class MethodPathAttribute : Attribute
    {
        public string Path { get; }

        public MethodPathAttribute(string path)
        {
            Path = path;
        }
    }

    public enum RiotMethod
    {");

        foreach (var item in methodsByNamespace)
        {
            var methodClass = item.MethodClass;
            var typeSymbol = item.TypeSymbol;

            var methodNamespace = GetNamespace(methodClass);
            var endpointNamespace = GetEndpointNamespace(methodNamespace);
            var endpointClassName = GetEndpointClassName(endpointNamespace);

            if (string.IsNullOrEmpty(endpointClassName))
                continue;

            var methodPath = GetMethodPath(typeSymbol);
            var endpointPath = GetEndpointPath(context, endpointClassName, endpointNamespace);
            var enumName = $"{endpointClassName}{methodClass.Identifier.Text}";

            var rateLimits = GetRateLimits(typeSymbol);

            sourceBuilder.AppendLine($@"
        [EndpointPath(""{endpointPath}"")]
        [MethodPath(""{methodPath}"")]");

            foreach (var rateLimit in rateLimits)
                sourceBuilder.AppendLine($@"        [RateLimit({rateLimit.TimeUnit}, {rateLimit.Value}, {rateLimit.Count})]");

            sourceBuilder.AppendLine($"        {enumName},");
        }

        sourceBuilder.AppendLine(@"
    }

    public static class RiotMethodExtensions
    {
        public static string GetEndpointPath(this RiotMethod method)
        {
            var field = typeof(RiotMethod).GetField(method.ToString());
            var attribute = (EndpointPathAttribute)Attribute.GetCustomAttribute(field, typeof(EndpointPathAttribute));
            return attribute?.Path ?? string.Empty;
        }

        public static string GetMethodPath(this RiotMethod method)
        {
            var field = typeof(RiotMethod).GetField(method.ToString());
            var attribute = (MethodPathAttribute)Attribute.GetCustomAttribute(field, typeof(MethodPathAttribute));
            return attribute?.Path ?? string.Empty;
        }

        public static string GetFullPath(this RiotMethod method)
        {
            return method.GetEndpointPath() + method.GetMethodPath();
        }

        public static Dictionary<TimeSpan, int> GetRateLimits(this RiotMethod method)
        {
            var rateLimits = new Dictionary<TimeSpan, int>();

            var field = typeof(RiotMethod).GetField(method.ToString());
            var attributes = Attribute.GetCustomAttributes(field, typeof(RateLimitAttribute));

            foreach (var attribute in attributes)
            {
                var rateLimit = (RateLimitAttribute)attribute;
                var rule = rateLimit.Unit switch
                {
                    TimeUnit.Milliseconds => TimeSpan.FromMilliseconds(rateLimit.Rule),
                    TimeUnit.Seconds => TimeSpan.FromSeconds(rateLimit.Rule),
                    TimeUnit.Minutes => TimeSpan.FromMinutes(rateLimit.Rule),
                    TimeUnit.Hours => TimeSpan.FromHours(rateLimit.Rule),
                    TimeUnit.Days => TimeSpan.FromDays(rateLimit.Rule),
                    _ => TimeSpan.FromSeconds(rateLimit.Rule)
                };

                rateLimits.Add(rule, rateLimit.Limit);
            }

            return rateLimits;
        }
    }
}");

        context.AddSource("RiotMethod.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
    }

    private bool ImplementsIMethod(INamedTypeSymbol typeSymbol)
    {
        return typeSymbol.AllInterfaces.Any(i => i.Name == "IMethod");
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

    private string GetMethodPath(INamedTypeSymbol typeSymbol)
    {
        foreach (var attribute in typeSymbol.GetAttributes().Where(attribute => attribute.AttributeClass?.Name == "MethodAttribute").Where(attribute => attribute.ConstructorArguments.Length > 0))
            return attribute.ConstructorArguments[0].Value?.ToString() ?? "";

        return "";
    }

    private string GetEndpointPath(GeneratorExecutionContext context, string endpointClassName, string endpointNamespace)
    {
        foreach (var syntaxTree in context.Compilation.SyntaxTrees)
        {
            var semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
            var classes = syntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>();

            foreach (var classDeclaration in classes)
            {
                if (classDeclaration.Identifier.Text != endpointClassName)
                    continue;

                if (semanticModel.GetDeclaredSymbol(classDeclaration) is not INamedTypeSymbol classSymbol || GetNamespace(classDeclaration) != endpointNamespace)
                    continue;

                foreach (var attribute in classSymbol.GetAttributes().Where(attribute => attribute.AttributeClass?.Name == "EndpointAttribute").Where(attribute => attribute.ConstructorArguments.Length > 0))
                    return attribute.ConstructorArguments[0].Value?.ToString() ?? "";
            }
        }

        return "";
    }

    private List<(string TimeUnit, int Value, int Count)> GetRateLimits(INamedTypeSymbol typeSymbol)
    {
        var rateLimits = new List<(string TimeUnit, int Value, int Count)>();

        var rateLimitAttributes = typeSymbol.GetAttributes().Where(attr => attr.AttributeClass?.Name == "RateLimitAttribute");

        foreach (var attribute in rateLimitAttributes)
        {
            if (attribute.ConstructorArguments.Length < 3)
                continue;

            var timeUnit = "TimeUnit.Seconds";

            if (attribute.ConstructorArguments[0].Value != null)
                timeUnit = attribute.ConstructorArguments[0].Value.ToString();

            timeUnit = timeUnit switch
            {
                "0" => "TimeUnit.Milliseconds",
                "1" => "TimeUnit.Seconds",
                "2" => "TimeUnit.Minutes",
                "3" => "TimeUnit.Hours",
                "4" => "TimeUnit.Days",
                _ => timeUnit
            };

            var timeValue = 0;

            if (attribute.ConstructorArguments[1].Value is int value)
                timeValue = value;

            var count = 0;

            if (attribute.ConstructorArguments[2].Value is int countValue)
                count = countValue;

            rateLimits.Add((timeUnit, timeValue, count));
        }

        return rateLimits;
    }
}