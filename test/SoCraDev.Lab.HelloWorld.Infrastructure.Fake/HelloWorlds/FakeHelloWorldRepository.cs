using SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;
using SoCraDev.Lab.HelloWorld.Core.Exceptions;

namespace SoCraDev.Lab.HelloWorld.Infrastructure.Fake.HelloWorlds;

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