using FluentAssertions;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Test.Common;
using Xunit;

namespace Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Test;

public class HelloWorldRepositoryShould : BaseTest
{
    private readonly IHelloWorldRepository _repository;
    private readonly IHelloWorldIdGenerator _idGenerator;

    public HelloWorldRepositoryShould(HostFixture fixture) : base(fixture)
    {
        _repository = GetService<IHelloWorldRepository>();
        _idGenerator = GetService<IHelloWorldIdGenerator>();
    }

    [Fact]
    public async Task Retrieve_added_helloWorld_entity()
    {
        var id = _idGenerator.Next();
        var name = HelloWorldName.From("Alex");
        var helloworldEntity = new HelloWorldEntity(id, name);
        
        _repository.Add(helloworldEntity);

        var retrievedHelloWorld = await _repository.GetAsync(id);

        retrievedHelloWorld.Should().BeEquivalentTo(helloworldEntity);
    }
}