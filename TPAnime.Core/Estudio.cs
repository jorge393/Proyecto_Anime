namespace TPAnime.Core
{
    public class Estudio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }

        public Estudio() { 
        }
        public Estudio(string nombre, string domicilio)
        {
            Nombre = nombre;
            Domicilio = domicilio;
        }
    }
}