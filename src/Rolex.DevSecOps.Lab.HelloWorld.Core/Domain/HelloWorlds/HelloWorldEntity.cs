using System.Runtime.CompilerServices;

namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;

public record HelloWorldEntity(HelloWorldId helloWorldId, HelloWorldName name)
{
    protected HelloWorldEntity(HelloWorldEntity other)
    {
        this.helloWorldId = other.helloWorldId;
        this.name = other.name;
    }
}