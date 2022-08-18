namespace TPAnime.Core
{
    public class Anime
    {
        
    private int Id {get;set;} 
    private string Nombre {get;set;} 
    private string Genero {get;set;}
    private int Episodios {get;set;} 
    private DateTime Lanzamiento {get;set;} 
    private string Estado {get;set;} 
    private Estudio Estudio;
    private Autor Autor;

    public Anime(string nombre, string genero,int episodios,DateTime lanzamiento,string estado )
    {
        Nombre = nombre;
        Genero = genero;
        Episodios = episodios;
        Lanzamiento = lanzamiento;
        Estado = estado;
    }
    }
}