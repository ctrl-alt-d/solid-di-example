# solid-di-example

## Dog CEO via IHttpClientFactory (MVC)

Aquest projecte ja exposa aquestes peces:

- `IFotoDogService` a `FotoService.Abstractions`
- `FotoDogCeoService` a `FotoServiceDogCeo`

Per usar-ho des d'una aplicacio ASP.NET Core MVC, registra DI al `Program.cs`:

```csharp
using FotoService.Abstractions;
using FotoServiceDogCeo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IFotoDogService, FotoDogCeoService>();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.Run();
```

Notes:

- `FotoDogCeoService` injecta directament `IHttpClientFactory` i crea `HttpClient` amb `CreateClient()`, com al patro de "uso basico" de la documentacio.
- La crida actual fa `GET https://dog.ceo/api/breeds/image/random` i retorna el camp `message`.
- `IHttpClientFactory` gestiona la vida dels `HttpMessageHandler` i evita problemes tipics de sockets/DNS.
