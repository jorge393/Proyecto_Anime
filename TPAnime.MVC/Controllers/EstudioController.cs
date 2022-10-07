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
    // ELIMINAR ESTUDIO
    [HttpPost]
    public IActionResult EliminarEstudio(Estudio estudio)
    {
        Estudio estudioDelete = Ado.EstudioPorid(estudio.Id);
        if (estudioDelete is null)
        {
            return NotFound();
        }
        else
            Ado.eliminarEstudio(estudioDelete);
        
        return View("Lista", Ado.obtenerEstudio());
    }

    // ACTUALIZAR ESTUDIO
    [HttpGet]
    public IActionResult ActualizarEstudio(int id)
    {
        Estudio estudioUpdate = Ado.EstudioPorid(id);
        if (estudioUpdate is null)
        {
            return NotFound();
        }
        else
            return View(estudioUpdate);
    }

    [HttpPost]
    public IActionResult ActualizarEstudio(Estudio estudio)
    {
        Ado.actualizarEstudio(estudio);
        return View("Lista", Ado.obtenerEstudio());
    }
}

