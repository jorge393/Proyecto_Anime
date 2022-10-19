using Microsoft.AspNetCore.Mvc;
using TPAnime.MVC.ViewModels;
using TPAnime.Core;

namespace TPAnime.MVC.Controllers;

public class AnimeController : Controller
{
    private readonly IAdo Ado;
    public AnimeController(IAdo ado) => Ado = ado;

    [HttpGet]
    public IActionResult Index()
    {
        return View("Lista", Ado.obtenerAnimes());
    }

    [HttpGet]
    public IActionResult AgregarAnime()
    {
        var Estudios = Ado.obtenerEstudio();
        var Autores = Ado.obtenerAutores();
        var vmAnime = new VMAnime(Estudios, Autores);
        return View(vmAnime);
    }

    [HttpPost]
    public IActionResult AgregarAnime(VMAnime vmAnime)
    {
        if (!ModelState.IsValid)
            return View(vmAnime);

        if (vmAnime.IdAnime == 0)
        {
            var estudio = Ado.EstudioPorid(vmAnime.IdEstudio);
            var autor = Ado.AutorPorid(vmAnime.idAutor);
            var Anime = new Anime(vmAnime.NombreAnime!, vmAnime.GeneroAnime!, vmAnime.EpisodiosAnime!, vmAnime.LanzamientoAnime, vmAnime.EstadoAnime!, estudio, autor);
            Ado.altaAnime(Anime);
        }
        return Redirect(nameof(Index));
    }

    [HttpGet]
    public IActionResult ActualizarAnime(int? Id)
    {
        if (Id is null || Id == 0)
            return NotFound();

        var anime = Ado.AnimePorid(Id);
        if (anime is null)
            return NotFound();

        var estudios = Ado.obtenerEstudio();
        var autores = Ado.obtenerAutores();
        var vmAnime = new VMAnime(estudios, autores, anime);
        return View(vmAnime);
    }
    [HttpPost]
    public IActionResult ActualizarAnime(VMAnime vmAnime)
    {
        var estudio = Ado.EstudioPorid(vmAnime.IdEstudio);
        var autor = Ado.AutorPorid(vmAnime.idAutor);
        var Anime = new Anime(vmAnime.NombreAnime!, vmAnime.GeneroAnime!, vmAnime.EpisodiosAnime!, vmAnime.LanzamientoAnime!, vmAnime.EstadoAnime!, estudio, autor);
        Anime.Id = vmAnime.IdAnime;
        Ado.actualizarAnime(Anime);
        return View("Lista", Ado.obtenerAnimes());
    }
    [HttpPost]
    public IActionResult EliminarAnime(Anime anime)
    {
        Anime AnimeDelete = Ado.AnimePorid(anime.Id);
        if (AnimeDelete is null)
        {

        }

    }
}
