using System.Net;
using FluentAssertions;
using PactNet;
using SoCraDev.Lab.HelloWorld.Consumer.Infrastructure.Client;
using Xunit;

namespace SoCraDev.Lab.HelloWorld.Consumer.Test.Infrastructure.Client;

public class HelloWorldConsumerShould
{
    private readonly IPactBuilderV3 _pactBuilder;


    public HelloWorldConsumerShould()
    {
        var pact = Pact.V3(
            "HelloWorldDotnetConsumer", 
            "HelloWorldProvider", 
            new PactConfig
            {
                PactDir = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}{Path.DirectorySeparatorChar}pacts"
            }
            );
        this._pactBuilder = pact.WithHttpInteractions();
    }
    [Fact]
    public async Task Create_new_name_given_valid_request()
    {
        this._pactBuilder
            .UponReceiving("Post a new Hello World name")
            .Given("There's a new name 'Alex'")
            .WithRequest(HttpMethod.Post, "/hello-worlds")
            .WithJsonBody(new
            {
                name = "Alex"
            })
            .WillRespond()
            .WithStatus(HttpStatusCode.Created)
            .WithHeader("Content-type", "application/json; charset=utf-8")
            .WithJsonBody(new
            {
                helloWorldId = 5677
            });

        await this._pactBuilder.VerifyAsync(context =>
        {
            var client = new HelloWorldApiClient(context.MockServerUri);
            var response = client.Create("Alex");
            
            response.Should().NotBeNull();
            response.Status.Should().Be(TaskStatus.Created);
            response.IsCompletedSuccessfully.Should().BeTrue();
            response.Result!.HelloWorldId.Should().BePositive();
            return Task.CompletedTask;
        });

    }
}