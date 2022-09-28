using FluentAssertions;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Test.Common;
using Xunit;

namespace Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Test;

public class HelloWorldIdGeneratorShould : BaseTest
{
    private IHelloWorldIdGenerator _generator;

    public HelloWorldIdGeneratorShould(HostFixture fixture) : base(fixture)
    {
        _generator = GetService<IHelloWorldIdGenerator>();
    }

    [Fact]
    public void generate_helloworldid()
    {
        var helloworldid = _generator.Next();
        helloworldid.Should().NotBeNull();
    }
}