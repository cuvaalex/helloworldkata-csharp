using SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;
using SoCraDev.Lab.HelloWorld.Infrastructure.Fake.HelloWorlds;

namespace SoCraDev.Lab.HelloWorld.Test.Common.Setup;

public static class FakeHelloWorldIdGeneratorSetup
{
    public static void WillGenerate(this FakeHelloWorldIdGenerator generator, long helloWorldId)
    {
        generator.Enqueue(HelloWorldId.From(helloWorldId));
    }
}