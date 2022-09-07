using Microsoft.AspNetCore.Mvc;
using TPAnime.Core;
using TPAnime.AdoMySQL;

namespace TPAnime.MVC.Controllers;
public class AutoController : Controller
{
    [HttpGet]
    public IActionResult Index()
        => View();
}

