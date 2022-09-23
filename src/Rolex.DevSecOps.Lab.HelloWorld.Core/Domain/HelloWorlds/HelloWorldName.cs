using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.Common.Guards;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Exceptions;

namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;

public struct HelloWorldName
{
    
    public static HelloWorldName From(string name)
    {
        return new HelloWorldName(name);
    }
    private HelloWorldName(string name)
    {
        Name = name.GuardAgainstNullOrWhiteSpace(ValidationMessages.NameEmpty);
    }

    public string Name { get; }
}