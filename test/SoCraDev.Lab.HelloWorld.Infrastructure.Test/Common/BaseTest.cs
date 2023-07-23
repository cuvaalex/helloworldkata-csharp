using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace SoCraDev.Lab.HelloWorld.Infrastructure.Test.Common
{
    public class BaseTest : IClassFixture<HostFixture>
    {
        private readonly HostFixture _fixture;

        public BaseTest(HostFixture fixture)
        {
            _fixture = fixture;
        }

        public T GetService<T>() where T : notnull
        {
            return _fixture.HostInstance.Services.GetRequiredService<T>();
        }
    }
}
