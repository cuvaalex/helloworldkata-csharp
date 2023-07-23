using SoCraDev.Lab.HelloWorld.Core.Domain.Common.Guards;
using SoCraDev.Lab.HelloWorld.Core.Exceptions;

namespace SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;

public struct HelloWorldId
{
    public static HelloWorldId From(long id)
    {
        return new HelloWorldId(id);
    }
    private HelloWorldId(long id)
    {
        this.Value = id.GuardAgainstSmallerThan0(ValidationMessages.HelloWorldIdUnder0);
    }

    public long Value { get; }
}