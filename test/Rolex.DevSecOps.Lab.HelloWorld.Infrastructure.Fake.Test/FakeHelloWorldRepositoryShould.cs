using FluentAssertions;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Exceptions;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Fake.HelloWorlds;
using Xunit;

namespace Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Fake.Test;

public class FakeHelloWorldRepositoryShould
{
    private readonly FakeHelloWorldRepository _repository;

    public FakeHelloWorldRepositoryShould()
    {
        _repository = new FakeHelloWorldRepository();
    }

    [Fact]
    public async void Retrieve_added_helloworld_after_add()
    {
        var helloworldId = HelloWorldId.From(45677L);
        var name = HelloWorldName.From("Alex");

        var initialHelloWorld = new HelloWorldEntity(helloworldId, name);
        var expectedHelloWorld = new HelloWorldEntity(helloworldId, name);
        
        _repository.Add(initialHelloWorld);

        var retrieveHelloWorld = await _repository.GetAsync(helloworldId);
        retrieveHelloWorld.Should().BeEquivalentTo(expectedHelloWorld);
    }

    [Fact]
    public async void Throw_exception_when_id_already_exist()
    {
        var helloworldId = HelloWorldId.From(45677L);
        var name = HelloWorldName.From("Alex");

        var initialHelloWorld = new HelloWorldEntity(helloworldId, name);
        _repository.Add(initialHelloWorld);
        
        Action action = () => _repository.Add(initialHelloWorld);
        

        action.Should().ThrowExactly<RepositoryException>()
            .WithMessage(RepositoryMessages.RepositoryCannotUpdateNonExistent);

    }
    
    
}