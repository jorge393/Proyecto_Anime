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
        var b = Ado.AutorPorid()
        var a = Ado.obtenerAnimes();
        return View("Lista", Ado.obtenerAnimes());
    }
    [HttpGet]
    public IActionResult AgregarAnime()
        => View();

    [HttpPost]
    public IActionResult AgregarAnime(Anime anime)
    {
        Ado.altaAutor(anime);
        return View("Lista", Ado.obtenerAnimes());
    }
}
