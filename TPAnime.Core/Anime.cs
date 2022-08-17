namespace TPAnime.Core
{
    public class Anime
    {
        
    private int Id {get;set;} 
    private string nombre {get;set;} 
    private string genero {get;set;}
    private int episodios {get;set;} 
    private DateTime lanzamiento {get;set;} 
    private string estado {get;set;} 
    private Estudio estudio;
    private Autor autor;
    }
}