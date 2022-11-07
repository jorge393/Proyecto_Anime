using Microsoft.AspNetCore.Mvc;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;
public class EstudioController : Controller
{
    private readonly IAdo Ado;
    public EstudioController(IAdo ado) => Ado = ado;

    // VER ESTUDIOS
    [HttpGet]
    public async Task<IActionResult> Index()
        => View("Lista",await Ado.obtenerEstudioAsync());

    // AGREGAR ESTUDIO
    [HttpGet]
    public IActionResult AgregarEstudio() => View();

    [HttpPost]
    public async Task<IActionResult> AgregarEstudio(Estudio estudio)
    {
        await Ado.altaEstudioAsync(estudio);
        return View("Lista", await Ado.obtenerEstudioAsync());
    }
    // ELIMINAR ESTUDIO
    [HttpPost]
    public async Task<IActionResult> EliminarEstudio(Estudio estudio)
    {
         estudio = await Ado.EstudioPoridAsync(estudio.Id);
        if (estudio is null)
        {
            return NotFound();
        }
        else
            await Ado.eliminarEstudioAsync(estudio);

        return Redirect(nameof(Index));
    }

    // ACTUALIZAR ESTUDIO
    [HttpGet]
    public async Task<IActionResult> ActualizarEstudio(int id)
    {
        Estudio estudioUpdate = await Ado.EstudioPoridAsync(id);
        if (estudioUpdate is null)
        {
            return NotFound();
        }
        else
            return View(estudioUpdate);
    }

    [HttpPost]
    public async Task<IActionResult> ActualizarEstudio(Estudio estudio)
    {
        await Ado.actualizarEstudioAsync(estudio);
        return View("Lista",await Ado.obtenerEstudioAsync());
    }
}

