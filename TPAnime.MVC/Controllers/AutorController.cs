using Microsoft.AspNetCore.Mvc;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;
public class AutorController : Controller
{
    private readonly IAdo Ado;
    public AutorController(IAdo ado) => Ado = ado;

    // VER AUTORES
    [HttpGet]
    public IActionResult Index()
     => View("Lista", Ado.obtenerAutores());
    

    // AGREGAR AUTOR
    [HttpGet]
    public IActionResult AgregarAutor()
        => View();

    [HttpPost]
    public IActionResult AgregarAutor(Autor autor)
    {
        Ado.altaAutor(autor);
        return View("Lista", Ado.obtenerAutores());
    }

    //ELIMINAR
    [HttpPost]
    public IActionResult EliminarAutor(Autor autor)
    {
        Autor autorEliminar = Ado.AutorPorid(autor.Id);
        if (autorEliminar is null)
        {
            return NotFound();
        }
        else
            Ado.eliminarAutor(autorEliminar);
        return View("Lista", Ado.obtenerAutores());
    }
    //ACTUALIZAR
    [HttpGet]
    public IActionResult ActualizarAutor(Autor autor)
    {
        Autor autorcap = Ado.AutorPorid(autor.Id);
        if (autorcap is null)
        {
            return NotFound();
        }
        else
        return View(autorcap);
    }

    [HttpPost]
    public IActionResult ActualizarAutora(Autor autor)
    {
        Ado.actualizarAutor(autor);
        return View("Lista", Ado.obtenerAutores());
    }
}

