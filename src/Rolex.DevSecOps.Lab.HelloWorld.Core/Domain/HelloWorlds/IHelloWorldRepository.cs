namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;

public interface IHelloWorldRepository
{
    void Add(HelloWorldEntity helloWorldEntity);
    Task<HelloWorldEntity> GetAsync(HelloWorldId helloworldId);
}