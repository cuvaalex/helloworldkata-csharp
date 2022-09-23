using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Rolex.DevSecOps.Lab.HelloWorld.System.Test.Controllers.Common;

public class HostFixture : IDisposable
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public HostFixture()
    {
        _webApplicationFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // var configuration = builder.Ser

                // builder.ConfigureServices(services => services.Register(builder.Conf))
                // TODO: ACU: Configure
            });

        Client = _webApplicationFactory.CreateClient();
    }

    public HttpClient Client { get; }

    public void Dispose()
    {
        Client.Dispose();
        _webApplicationFactory.Dispose();
    }
}