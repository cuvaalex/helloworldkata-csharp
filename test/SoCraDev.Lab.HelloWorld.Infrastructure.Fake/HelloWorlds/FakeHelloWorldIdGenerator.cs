using SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;
using SoCraDev.Lab.HelloWorld.Infrastructure.Fake.Exceptions;

namespace SoCraDev.Lab.HelloWorld.Infrastructure.Fake.HelloWorlds;

public class FakeHelloWorldIdGenerator : IHelloWorldIdGenerator
{
    private readonly Queue<HelloWorldId> _queue;

    public FakeHelloWorldIdGenerator()
    {
        _queue = new Queue<HelloWorldId>();
    }


    public HelloWorldId Next()
    {
        if (!_queue.Any())
        {
            throw new FakeException(FakeMessages.GeneratorDoesNotHaveNext);
        }

        return _queue.Dequeue();
    }

    public void WillGenerate(long expectedValue)
    {
        this.Enqueue(HelloWorldId.From(expectedValue));
    }

    public void Enqueue(HelloWorldId helloWorldId)
    {
        _queue.Enqueue(helloWorldId);
    }
}