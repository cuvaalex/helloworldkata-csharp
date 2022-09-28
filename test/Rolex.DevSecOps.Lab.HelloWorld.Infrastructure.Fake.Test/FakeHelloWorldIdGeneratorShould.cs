using FluentAssertions;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Fake.Exceptions;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Fake.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Test.Common.Setup;
using Xunit;

namespace Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Fake.Test;

public class FakeHelloWorldIdGeneratorShould
{
    private FakeHelloWorldIdGenerator _generator;

    public FakeHelloWorldIdGeneratorShould()
    {
        _generator = new FakeHelloWorldIdGenerator();
    }

    [Fact]
    public void Should_throw_exception_when_no_elements()
    {
        var action = () => _generator.Next();

        action.Should().ThrowExactly<FakeException>()
            .WithMessage(FakeMessages.GeneratorDoesNotHaveNext);
    }

    [Fact]
    public void Should_return_next_element_when_there_is_one_element()
    {
        const long expectedValue = 2323523523L;

        _generator.WillGenerate(expectedValue);

        ShouldGenerateNext(expectedValue);
        ShouldThrowExceptionOnNext();
    }

    [Fact]
    public void Should_return_next_elements_when_there_are_multiple_elements()
    {
        const long expectedValue1 = 3523523L;
        const long expectedValue2 = 3462234234L;
        const long expectedValue3 = 524523523523L;

        _generator.WillGenerate(expectedValue1);
        _generator.WillGenerate(expectedValue2);
        _generator.WillGenerate(expectedValue3);

        ShouldGenerateNext(expectedValue1);
        ShouldGenerateNext(expectedValue2);
        ShouldGenerateNext(expectedValue3);

        ShouldThrowExceptionOnNext();
    }

    private void ShouldGenerateNext(long accountId)
    {
        var next = _generator.Next();
        next.Should().Be(HelloWorldId.From(accountId));
    }

    private void ShouldThrowExceptionOnNext()
    {
        var action = () => _generator.Next();

        action.Should().Throw<FakeException>()
            .WithMessage(FakeMessages.GeneratorDoesNotHaveNext);
    }
    
    
}