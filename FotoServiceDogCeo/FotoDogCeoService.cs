using FotoService.Abstractions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FotoServiceDogCeo;

public class FotoDogCeoService(IHttpClientFactory httpClientFactory) : IFotoDogService
{
    private const string RandomDogImageEndpoint = "https://dog.ceo/api/breeds/image/random";

    private string? UrlCache = null;

    public async Task<string> GetRandomDogImageUrlAsync()
    {
        if (UrlCache != null)
        {
            return UrlCache;
        }

        var httpClient = httpClientFactory.CreateClient();
        using var responseMessage = await httpClient.GetAsync(RandomDogImageEndpoint);
        responseMessage.EnsureSuccessStatusCode();

        var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<DogCeoResponse>(jsonResponse);

        if (response is null ||
            !string.Equals(response.Status, "success", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrWhiteSpace(response.Message))
        {
            throw new InvalidOperationException("Unexpected response received from Dog CEO API.");
        }

        UrlCache = response.Message;
        return UrlCache;
    }

    private sealed record DogCeoResponse(
        [property: JsonPropertyName("message")] string Message,
        [property: JsonPropertyName("status")] string Status);
}
