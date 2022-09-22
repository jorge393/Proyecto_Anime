using Microsoft.AspNetCore.Mvc;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;
public class AutorController : Controller
{
    private readonly IAdo Ado;
    public AutorController(IAdo ado) => Ado = ado;

    [HttpGet]
    public IActionResult Index()
        => View("Lista", Ado.obtenerAutores());

    // [HttpGet]
    // public IActionResult Detalle(int id)
    // {
    //     var Autor = Ado.altaAutor
    // }
}

