using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Fake.HelloWorlds;

namespace Rolex.DevSecOps.Lab.HelloWorld.Test.Common.Setup;

public static class FakeHelloWorldIdGeneratorSetup
{
    public static void WillGenerate(this FakeHelloWorldIdGenerator generator, long helloWorldId)
    {
        generator.Enqueue(HelloWorldId.From(helloWorldId));
    }
}