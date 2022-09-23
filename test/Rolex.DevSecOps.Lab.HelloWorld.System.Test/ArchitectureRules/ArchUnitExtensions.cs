using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Rolex.DevSecOps.Lab.HelloWorld.Core.UseCases.HelloWorld;

namespace Rolex.DevSecOps.Lab.HelloWorld.System.Test.ArchitectureRules;

public static class ArchUnitExtensions
{
    private static readonly Architecture Architecture =
        new ArchLoader()
            .LoadAssemblies(typeof(HelloWorldUseCase).Assembly)
            .Build();

    public static void Check(this IArchRule rule)
        => rule.Check(Architecture);
}