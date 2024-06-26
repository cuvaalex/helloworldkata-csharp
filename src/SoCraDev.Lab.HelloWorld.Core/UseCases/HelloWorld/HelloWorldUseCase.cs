﻿using MediatR;
using SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;

namespace SoCraDev.Lab.HelloWorld.Core.UseCases.HelloWorld;

public class HelloWorldUseCase : IRequestHandler<HelloWorldRequest, HelloWorldResponse>
{
    private readonly IHelloWorldIdGenerator _helloWorldIdGenerator;
    private readonly IHelloWorldRepository _repository;

    public HelloWorldUseCase(IHelloWorldIdGenerator helloWorldIdGenerator, IHelloWorldRepository repository)
    {
        _helloWorldIdGenerator = helloWorldIdGenerator;
        _repository = repository;
    }

    public Task<HelloWorldResponse> Handle(HelloWorldRequest request, CancellationToken cancellationToken)
    {
        HelloWorldName name = HelloWorldName.From(request.name);
        var helloWorldId = _helloWorldIdGenerator.Next();

        var helloWorld = new HelloWorldEntity(helloWorldId, name);
        _repository.Add(helloWorld);

        var response = new HelloWorldResponse(helloWorldId);

        return Task.FromResult(response);
    }

}
