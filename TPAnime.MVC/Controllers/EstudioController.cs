using Microsoft.AspNetCore.Mvc;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;
public class EstudioController : Controller
{
    private readonly IAdo Ado;
    public EstudioController(IAdo ado) => Ado = ado;

    [HttpGet]
    public IActionResult Index()
        => View("Lista", Ado.obtenerEstudio());

    [HttpGet]
    public IActionResult AgregarEstudio() => View();

    [HttpPost]
    public IActionResult AgregarEstudio(Estudio estudio)
    {
        Ado.altaEstudio(estudio);
        return View();
    }
}

