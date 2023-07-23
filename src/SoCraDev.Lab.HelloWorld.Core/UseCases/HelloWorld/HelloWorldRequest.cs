using MediatR;

namespace SoCraDev.Lab.HelloWorld.Core.UseCases.HelloWorld;

public record HelloWorldRequest(string name) : IRequest<HelloWorldResponse>
{
}