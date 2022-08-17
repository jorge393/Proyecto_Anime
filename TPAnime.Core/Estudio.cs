namespace TPAnime.Core
{
    public class Estudio
    {
        private int Id {get;set;}
        private string Nombre {get;set;}
        private string Domicilio {get;set;}
        
    public Estudio(int id, string nombre, string domicilio)
    {
        Id = id;
        Nombre = nombre;
        Domicilio = domicilio;
    }
    }
}