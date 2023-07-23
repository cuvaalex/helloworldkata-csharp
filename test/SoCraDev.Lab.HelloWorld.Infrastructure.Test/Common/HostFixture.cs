using Microsoft.Extensions.Hosting;
using SoCraDev.Lab.HelloWorld.CompositionRoot.Extensions;

namespace SoCraDev.Lab.HelloWorld.Infrastructure.Test.Common
{
    public class HostFixture : IDisposable
    {
        public HostFixture()
        {
            var args = Array.Empty<string>();
            HostInstance = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => services.Register(hostContext.Configuration))
                .Build();
        }

        public IHost HostInstance { get; }

        public void Dispose()
        {
            HostInstance.Dispose();
        }
    }
}
