using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.Common.Guards;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Exceptions;

namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;

public struct HelloWorldId
{
    public static HelloWorldId From(long id)
    {
        return new HelloWorldId(id);
    }
    private HelloWorldId(long id)
    {
        this.helloWorldId = id.GuardAgainstSmallerThan0(ValidationMessages.HelloWorldIdUnder0);
    }

    public long helloWorldId { get; }
}