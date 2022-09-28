using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rolex.DevSecOps.Lab.HelloWorld.CompositionRoot.Extensions;

namespace Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Test.Common
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
