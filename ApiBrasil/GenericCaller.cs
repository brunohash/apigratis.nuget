using RestSharp;
using ApiBrasil.Domain;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Threading.Tasks;

namespace ApiBrasil
{
    public static class GenericCaller
    {
        public static async Task<string> Call(string type, string action, object content, ApiBrasilConfiguration config)
        {
            var options = new RestClientOptions("https://cluster-01.apigratis.com")
            {
                MaxTimeout = -1
            };

            var client = new RestClient(options);
            var request = new RestRequest($"/api/v1/{type}/{action}", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("SecretKey", config.SecretKey ?? "");
            request.AddHeader("PublicToken", config.PublicToken ?? "");
            request.AddHeader("DeviceToken", config.DeviceToken ?? "");
            request.AddHeader("Authorization", $"Bearer {config.Authorization}");
            var body = content;
            //request.AddStringBody(body.ToString(), "application/json");
            request.AddObject<object>(body);

            var response = await client.ExecuteAsync(request);
            return response.Content ?? "";
        }
    }
}


