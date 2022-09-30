using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;

namespace Rolex.DevSecOps.Lab.HelloWorld.Core.UseCases.HelloWorld;

public record HelloWorldResponse(long? HelloWorldId)
{
    public HelloWorldResponse(HelloWorldId? helloWorldId) : this(helloWorldId.Value.Value)
    {
        
    }
}