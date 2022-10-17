using Microsoft.AspNetCore.Mvc;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;

public class AnimeController : Controller
{
    private readonly IAdo Ado;
    public AnimeController(IAdo ado) => Ado = ado;

    [HttpGet]
    public IActionResult Index()
    {
        return View("Lista", Ado.obtenerAnimes());
    }
}
