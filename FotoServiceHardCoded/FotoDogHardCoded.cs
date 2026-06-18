using FotoService.Abstractions;

namespace FotoServiceDogCeo;

public class FotoDogHardCoded: IFotoDogService
{
    public Task<string> GetRandomDogImageUrlAsync()
    {
        return Task.FromResult("https://images.dog.ceo/breeds/pekinese/n02086079_2935.jpg");
    }
}
