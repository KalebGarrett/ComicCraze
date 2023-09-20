using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ComicCraze.Web.Models;
using ComicCraze.Web.Services;

namespace ComicCraze.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ComicService _comicService;

    public HomeController(ILogger<HomeController> logger, ComicService comicService)
    {
        _logger = logger;
        _comicService = comicService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new IndexViewModel();
        model.Comic = await _comicService.GetAll();
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}