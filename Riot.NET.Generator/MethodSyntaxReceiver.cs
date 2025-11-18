using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Riot.NET.Generator;

public class MethodSyntaxReceiver : ISyntaxReceiver
{
    public List<ClassDeclarationSyntax> MethodClasses { get; } = [];

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        // Collect classes that:
        // 1. Implement IMethod<TResponse> directly
        // 2. Inherit from MethodBase<TResponse>, RegionMethodBase<TResponse>, or ShardMethodBase<TResponse>, or StaticShardMethodBase<TResponse>
        // 3. Have any class in their inheritance chain that meets condition 1 or 2
        if (syntaxNode is ClassDeclarationSyntax classDeclaration && classDeclaration.BaseList != null)
        {
            var baseTypes = classDeclaration.BaseList.Types;

            if (baseTypes.Any(t =>
                    t.Type.ToString().StartsWith("IMethod<") ||
                    t.Type.ToString().StartsWith("MethodBase<") ||
                    t.Type.ToString().StartsWith("RegionMethodBase<") ||
                    t.Type.ToString().StartsWith("ShardMethodBase<") ||
                    t.Type.ToString().StartsWith("StaticShardMethodBase<") ||
                    t.Type.ToString().StartsWith("StaticShardAccessTokenMethodBase<") ||
                    t.Type.ToString().StartsWith("RegionAccessTokenMethodBase<") ||
                    t.Type.ToString().StartsWith("DataDragonMethodBase<") ||
                    t.Type.ToString().StartsWith("DataDragonDataMethodBase<") ||
                    t.Type.ToString().StartsWith("DataDragonFilteredDataMethodBase<") ||
                    t.Type.ToString().StartsWith("ValorantApiMethodBase<") ||
                    t.Type.ToString().StartsWith("ValorantApiDataMethodBase<") ||
                    t.Type.ToString().StartsWith("ValorantApiFilteredDataMethodBase<")))
            {
                MethodClasses.Add(classDeclaration);
            }
        }
    }
}