using IdGen;
using SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;

namespace SoCraDev.Lab.HelloWorld.Infrastructure;

public class HelloWorldIdGenerator : IHelloWorldIdGenerator
{
    private const int GeneratorId = 0;
    private readonly IdGenerator _idGenerator;

    public HelloWorldIdGenerator()
    {
        _idGenerator = new IdGenerator(GeneratorId);
    }

    public HelloWorldId Next()
    {
        var value = _idGenerator.CreateId();
        return HelloWorldId.From(value);
    }
}