using Microsoft.AspNetCore.Mvc;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;
public class EstudioController : Controller
{
    private readonly IAdo Ado;
    public EstudioController(IAdo ado) => Ado = ado;
    
    // VER ESTUDIOS
    [HttpGet]
    public IActionResult Index()
        => View("Lista", Ado.obtenerEstudio());

    // AGREGAR ESTUDIO
    [HttpGet]
    public IActionResult AgregarEstudio() => View();

    [HttpPost]
    public IActionResult AgregarEstudio(Estudio estudio)
    {
        Ado.altaEstudio(estudio);
        return View("Lista", Ado.obtenerEstudio());
    }
    // 
}

