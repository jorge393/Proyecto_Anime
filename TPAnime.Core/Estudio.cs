namespace TPAnime.Core
{
    public class Estudio
    {
        private int Id {get;set;}
        private string Nombre {get;set;}
        private string Domicilio {get;set;}
        
    public Estudio(string nombre, string domicilio)
    {
        Nombre = nombre;
        Domicilio = domicilio;
    }
    }
}