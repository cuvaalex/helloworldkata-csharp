using System.Net;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SoCraDev.Lab.HelloWorld.Consumer.Infrastructure.Client;

public class HelloWorldApiClient
{
    private readonly Uri _baseUri;

    public HelloWorldApiClient(Uri baseUri)
    {
        _baseUri = baseUri;
    }

    public async Task<HelloWorldResponse?> Create(string name)
    {
        var request = new HelloWorldRequest(name);
        
        using (var client = new HttpClient { BaseAddress = _baseUri })
        {
            try
            {
                var response = await client.PostAsJsonAsync(requestUri: "/hello-worlds", request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<HelloWorldResponse>();
                    return content;
                }

            }
            catch (Exception ex)
            {
                throw new HttpRequestException(
                    string.Format("The HelloWorld API request for {0} {1} failed.",
                        "POST",
                        "/hello-worlds"), ex);
            }
        }

        return null;
    }

    
    public record HelloWorldRequest(string name){}
    public record HelloWorldResponse(long? HelloWorldId){}
}