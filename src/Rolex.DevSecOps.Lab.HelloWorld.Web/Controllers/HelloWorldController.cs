using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rolex.DevSecOps.Lab.HelloWorld.Core.UseCases.HelloWorld;
using Rolex.DevSecOps.Lab.HelloWorld.Core.UseCases.ViewHelloWorldName;

namespace Rolex.DevSecOps.Lab.HelloWorld.Web.Controllers;

[ApiController]
[Route("hello-worlds")]
public class HelloWorldController : ControllerBase
{
    private readonly IMediator _mediator;

    public HelloWorldController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<HelloWorldResponse>> CreateName(HelloWorldRequest request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtAction(nameof(ViewName), new { helloWorldId = response.HelloWorldId }, response);
    }
    

    [HttpGet("{helloWorldId}")]
    public async Task<ActionResult<ViewHelloWorldNameResponse>> ViewName(long helloWorldId)
    {
        throw new NotImplementedException();
    }
    

}