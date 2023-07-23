using System.Text;
using Newtonsoft.Json;
using SoCraDev.Lab.HelloWorld.System.Test.Controllers.Common;
using SoCraDev.Lab.HelloWorld.Core.UseCases.HelloWorld;
using Xunit;

namespace SoCraDev.Lab.HelloWorld.System.Test.Controllers;

public class HelloWorldControllerSystemTest : BaseTest
{
    public HelloWorldControllerSystemTest(HostFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task Should_create_new_name_given_valid_request()
    {
        var url = "hello-worlds";

        var request = new HelloWorldRequest("Alex");

        var json = JsonConvert.SerializeObject((request));
        var body = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PostAsync(url, body);

        response.EnsureSuccessStatusCode();
    }
}