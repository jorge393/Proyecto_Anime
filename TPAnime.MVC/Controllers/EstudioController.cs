using Microsoft.AspNetCore.Mvc;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;
public class EstudioController : Controller
{
    private readonly IAdo Ado;
    public EstudioController(IAdo ado) => Ado = ado;

    [HttpGet]
    public IActionResult Index()
        => View("Lista", Ado.obtenerAutores());

    // [HttpGet]
    // public IActionResult Detalle(int id)
    // {
    //     var categoria = Ado.obtenerAutores(id);
    //     if (categoria is null)
    //     {
    //         return NotFound();
    //     }
    //     return View(categoria);
    // }

    [HttpGet]
    public IActionResult FormAlta() => View();

    [HttpPost]
    public IActionResult FormAlta(Autor autor)
    {
        Ado.altaAutor(autor);
        return View("Index", Ado.obtenerAutores());
    }

    // [HttpPost]
    // public IActionResult Eliminar(int id)
    // {
    //     var categoria = Repositorio.GetCategoria(id);
    //     if (categoria is null)
    //     {
    //         return NotFound();
    //     }
    //     Repositorio.EliminarCategoria(categoria);
    //     return View("Index", Repositorio.Categorias);
    // }

    // [HttpGet]
    // public IActionResult Modificar(int id)
    // {
    //     var categoria = Repositorio.GetCategoria(id);
    //     if (categoria is null)
    //     {
    //         return NotFound();
    //     }
    //     return View(categoria);
    // }

//     [HttpPost]
//     public IActionResult Modificar(Categoria categoria)
//     {
//         Repositorio.ActualizarCategoria(categoria);
//         return View("Index", Repositorio.Categorias);
//     }
 }
