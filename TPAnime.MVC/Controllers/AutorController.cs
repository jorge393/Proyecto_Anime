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
    [HttpGet]

    // AGREGAR AUTOR
    public IActionResult AgregarAutor()
        => View();
    
    [HttpPost]
    public IActionResult AgregarAutor(Autor autor)
    {
        Ado.altaAutor(autor);
        return View("Lista", Ado.obtenerAutores());
    }

    // ELIMINAR AUTOR
    // [HttpGet]
    // public IActionResult EliminarAutor()
    //     => View();
    [HttpPost]
    public IActionResult EliminarAutor(Autor autor)
    {
        Ado.eliminarAutor(autor);
        return View("Lista", Ado.obtenerAutores());
    }
}

