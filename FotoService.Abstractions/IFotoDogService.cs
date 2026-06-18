namespace FotoService.Abstractions;

public interface IFotoDogService
{
    Task<string> GetRandomDogImageUrlAsync();
}
