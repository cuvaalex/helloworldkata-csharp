﻿using FluentAssertions;
using SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;
using SoCraDev.Lab.HelloWorld.Core.UseCases.HelloWorld;
using SoCraDev.Lab.HelloWorld.Core.Exceptions;
using SoCraDev.Lab.HelloWorld.Infrastructure.Fake.HelloWorlds;
using SoCraDev.Lab.HelloWorld.Test.Common.Data;
using Xunit;

namespace SoCraDev.Lab.HelloWorld.Core.Test.UseCase;

public class HelloWorldUseCaseShould
{
    private HelloWorldUseCase _useCase;
    private readonly FakeHelloWorldIdGenerator _idGenerator;
    private readonly IHelloWorldRepository _repository;

    public HelloWorldUseCaseShould()
    {
        _idGenerator = new FakeHelloWorldIdGenerator();
        _repository = new FakeHelloWorldRepository();
        _useCase = new HelloWorldUseCase(_idGenerator, _repository);
    }

    [Theory]
    [ClassData(typeof(NullEmptyWhitespaceStringData))]
    public async Task Should_throw_exception_given_empty_name(string name)
    {
        var request = new HelloWorldRequest(name);

        Func<Task> action = () => _useCase.Handle(request, CancellationToken.None);

        await action.Should().ThrowAsync<ValidationException>()
            .WithMessage(ValidationMessages.NameEmpty);
    }
    
    [Theory]
    [InlineData("Alex", 3456789L)]
    public async Task Return_new_helloWorld_given_valid_request(String name, long generatedHelloWorldId)
    {
        _idGenerator.WillGenerate(generatedHelloWorldId);

        var request = new HelloWorldRequest(name);
        var expectedResponse = new HelloWorldResponse(generatedHelloWorldId);

        var response = await _useCase.Handle(request, CancellationToken.None);

        response.Should().BeEquivalentTo(expectedResponse);
        
    }
}



