using Microsoft.AspNetCore.Mvc;
using TPAnime.MVC.ViewModels;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;

public class AnimeController : Controller
{
    private readonly IAdo Ado;
    public AnimeController(IAdo ado) => Ado = ado;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View("Lista",await Ado.obtenerAnimesAsync());
    }

    [HttpGet]
    public async Task<IActionResult> AgregarAnime()
    {
        var Estudios = await Ado.obtenerEstudioAsync();
        var Autores = await Ado.obtenerAutoresAsync();
        var vmAnime = new VMAnime(Estudios, Autores);
        return View(vmAnime);
    }

    [HttpPost]
    public async Task<IActionResult> AgregarAnime(VMAnime vmAnime)
    {
        if (!ModelState.IsValid)
            return View(vmAnime);

        if (vmAnime.IdAnime == 0)
        {
            var estudio = await Ado.EstudioPoridAsync(vmAnime.IdEstudio);
            var autor = await Ado.AutorPoridAsync(vmAnime.idAutor);
            var Anime = new Anime(vmAnime.NombreAnime!, vmAnime.GeneroAnime!, vmAnime.EpisodiosAnime!, vmAnime.LanzamientoAnime, vmAnime.EstadoAnime!, estudio, autor);
            await Ado.altaAnimeAsync(Anime);
        }
        return Redirect(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> ActualizarAnime(int? Id)
    {
        if (Id is null || Id == 0)
            return NotFound();

        var anime = await Ado.AnimePoridAsync(Id);
        if (anime is null)
            return NotFound();

        var estudios =await Ado.obtenerEstudioAsync();
        var autores = await Ado.obtenerAutoresAsync();
        var vmAnime = new VMAnime(estudios, autores, anime);
        return View(vmAnime);
    }
    [HttpPost]
    public  async Task<IActionResult> ActualizarAnime(VMAnime vmAnime)
    {
        var estudio =await Ado.EstudioPoridAsync(vmAnime.IdEstudio);
        var autor = await Ado.AutorPoridAsync(vmAnime.idAutor);
        var Anime = new Anime(vmAnime.NombreAnime!, vmAnime.GeneroAnime!, vmAnime.EpisodiosAnime!, vmAnime.LanzamientoAnime!, vmAnime.EstadoAnime!, estudio, autor);
        Anime.Id = vmAnime.IdAnime;
        await Ado.actualizarAnimeAsync(Anime);
        return View("Lista", await Ado.obtenerAnimesAsync());
    }
    [HttpPost]
    public async Task<IActionResult> EliminarAnime(Anime anime)
    {
        Anime AnimeDelete = await Ado.AnimePoridAsync(anime.Id);
        if (AnimeDelete is null)
        {
            return NotFound();
        }
        else
            await Ado.eliminarAnimeAsync(anime);

        return Redirect(nameof(Index));
    }
}
