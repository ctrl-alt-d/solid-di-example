using System.Diagnostics;
using FotoService.Abstractions;
using Microsoft.AspNetCore.Mvc;
using web.Models;

namespace web.Controllers;

public class HomeController(
    IFotoDogService fotoDogService) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.UrlFotoGos = await fotoDogService.GetRandomDogImageUrlAsync();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
