using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Exceptions;

namespace Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Fake.HelloWorlds;

public class FakeHelloWorldRepository : IHelloWorldRepository
{
    private readonly Dictionary<HelloWorldId,HelloWorldEntity> _helloWorlds;

    public FakeHelloWorldRepository()
    {
        _helloWorlds = new Dictionary<HelloWorldId, HelloWorldEntity>();
    }

    public void Add(HelloWorldEntity helloWorldEntity)
    {
        var helloworldId = helloWorldEntity.helloWorldId;

        if (_helloWorlds.ContainsKey(helloworldId))
        {
            throw new RepositoryException(RepositoryMessages.RepositoryCannotUpdateNonExistent);
        }

        var cloneHelloWorld = helloWorldEntity with { };
        _helloWorlds.Add(helloworldId, cloneHelloWorld);
    }

    public Task<HelloWorldEntity> GetAsync(HelloWorldId helloworldId)
    {
        HelloWorldEntity helloWorldEntity = _helloWorlds[helloworldId];

        var clonedHelloWorldEntity = helloWorldEntity with { };

        return Task.FromResult(clonedHelloWorldEntity);
    }
}