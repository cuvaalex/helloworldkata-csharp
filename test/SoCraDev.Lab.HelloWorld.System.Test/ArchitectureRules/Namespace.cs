using System.Runtime.CompilerServices;

namespace SoCraDev.Lab.HelloWorld.System.Test.ArchitectureRules;

public static class Namespaces
{
    public const string Domain = "Domain";
    public const string UseCases = "UseCases";
    public const string Exceptions = "Exceptions";
    public const string Infrastructure = "Infrastructure";
    public static readonly string? CompilerServices = typeof(RuntimeHelpers).Namespace;   
}