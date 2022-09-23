namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;

public interface IHelloWorldIdGenerator
{
    HelloWorldId? Next();

    void WillGenerate(long expectedValue);
}