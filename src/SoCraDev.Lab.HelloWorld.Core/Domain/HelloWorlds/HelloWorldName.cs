using SoCraDev.Lab.HelloWorld.Core.Domain.Common.Guards;
using SoCraDev.Lab.HelloWorld.Core.Exceptions;

namespace SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;

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