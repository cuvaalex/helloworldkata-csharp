using Xunit;

namespace SoCraDev.Lab.HelloWorld.System.Test.Controllers.Common;

public class BaseTest : IClassFixture<HostFixture>
{
    private readonly HostFixture _fixture;

    public BaseTest(HostFixture fixture)
    {
        _fixture = fixture;
    }

    public HttpClient Client => _fixture.Client;
}