using System.Runtime.Serialization;

namespace SoCraDev.Lab.HelloWorld.Infrastructure.Fake.Exceptions;

[Serializable]
public class FakeException : Exception
{
    protected FakeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public FakeException(string? message) : base(message)
    {
    }
}