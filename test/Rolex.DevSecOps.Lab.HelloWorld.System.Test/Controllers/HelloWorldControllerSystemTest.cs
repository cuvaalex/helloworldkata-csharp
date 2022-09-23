using System.Text;
using Newtonsoft.Json;
using Rolex.DevSecOps.Lab.HelloWorld.Core.UseCases.HelloWorld;
using Rolex.DevSecOps.Lab.HelloWorld.System.Test.Controllers.Common;
using Xunit;

namespace Rolex.DevSecOps.Lab.HelloWorld.System.Test.Controllers;

public class HelloWorldControllerSystemTest : BaseTest
{
    public HelloWorldControllerSystemTest(HostFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip="System not working yet, remove when strike done")]
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