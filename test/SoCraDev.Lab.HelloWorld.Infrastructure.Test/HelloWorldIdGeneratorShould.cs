using FluentAssertions;
using SoCraDev.Lab.HelloWorld.Infrastructure.Test.Common;
using SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Xunit;

namespace SoCraDev.Lab.HelloWorld.Infrastructure.Test;

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