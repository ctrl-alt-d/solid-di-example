using Microsoft.Extensions.DependencyInjection;

namespace FotoServiceDogCeo.IntegrationTests;

public class DogCeoHttpIntegrationTests
{
    [Fact]
    public async Task GetRandomDogImageUrlAsync_WithRealHttpClientFactory_ReturnsAbsoluteHttpUrl()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();

        using var serviceProvider = services.BuildServiceProvider();
        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        var sut = new FotoDogCeoService(httpClientFactory);

        var dogImageUrl = await sut.GetRandomDogImageUrlAsync();

        Assert.False(string.IsNullOrWhiteSpace(dogImageUrl));
        Assert.True(Uri.TryCreate(dogImageUrl, UriKind.Absolute, out var parsedUri));
        Assert.True(
            parsedUri!.Scheme == Uri.UriSchemeHttp ||
            parsedUri.Scheme == Uri.UriSchemeHttps);
    }
}
