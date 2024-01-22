using RestSharp;
using ApiBrasil.Domain;

namespace ApiBrasil
{
    public static class GenericCaller
    {
        public static async Task<string> Call(string type, string action, object content, ApiBrasilConfiguration config)
        {
            var options = new RestClientOptions("https://gateway.apibrasil.io")
            {
                MaxTimeout = -1
            };

            var client = new RestClient(options);
            var request = new RestRequest($"/api/v2/{type}/{action}", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("DeviceToken", config.DeviceToken ?? "");
            request.AddHeader("Authorization", $"Bearer {config.Authorization}");
            request.AddHeader("User-Agent", "APIBRASIL/NUGET-DOTNET");
            request.AddJsonBody(content);

            var response = await client.ExecuteAsync(request);
            return response.Content ?? "";
        }
    }
}


