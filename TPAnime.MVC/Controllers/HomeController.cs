using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPAnime.MVC.Models;

namespace TPAnime.MVC.Controllers;

public class HomeController : Controller
{
    public ViewResult Index()
    {
        var hora = DateTime.Now.Hour;
        string momento = "Buenas tardes";
        if (hora<12) momento = "Buenos días";
        return View("PrimeraVista", momento);
    }



    
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
