using MediatR;

namespace Rolex.DevSecOps.Lab.HelloWorld.Core.UseCases.HelloWorld;

public record HelloWorldRequest(string name) : IRequest<HelloWorldResponse>
{
}