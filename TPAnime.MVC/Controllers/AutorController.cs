using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;
public class AutorController : Controller
{
    private readonly IAdo Ado;
    public AutorController(IAdo ado) => Ado = ado;

    // VER AUTORES
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var autores = await Ado.obtenerAutoresAsync();
        return View("Lista", autores);
    }




    // AGREGAR AUTOR
    [HttpGet]
    public IActionResult AgregarAutor() => View();

    [HttpPost]
    public async Task<IActionResult> AgregarAutor(Autor autor)
    {
        await Ado.altaAutorAsync(autor);
        return View("Lista", await Ado.obtenerAutoresAsync());
    }






    //ELIMINAR
    [HttpPost]
    public async Task<IActionResult> EliminarAutor(Autor autor)
    {

        autor = await Ado.AutorPoridAsync(autor.Id);

        if (autor is null)
        {
            return NotFound();
        }
        else
           await Ado.eliminarAutorAsync(autor);
        return Redirect(nameof(Index)); //solucion a el numero negativo al eliminar
    }
    //ACTUALIZAR
    [HttpGet]
    public async Task<IActionResult> ActualizarAutor(Autor autor)
    {
        Autor autorcap = await Ado.AutorPoridAsync(autor.Id);
        if (autorcap is null)
        {
            return NotFound();
        }
        else
            return View(autorcap);
    }

    [HttpPost]
    public async Task<IActionResult> ActualizarAutora(Autor autor)
    {
        await Ado.actualizarAutorAsync(autor);
        return View("Lista", await Ado.obtenerAutoresAsync());
    }
}

