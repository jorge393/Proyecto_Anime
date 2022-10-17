namespace TPAnime.Core
{
    public class Anime
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Episodios { get; set; }
        public DateTime Lanzamiento { get; set; }
        public string Estado { get; set; }
        public Estudio Estudio;
        public Autor Autor;

        public Anime() { }
        public Anime(string nombre, string genero, int episodios, DateTime lanzamiento, string estado, Estudio estudio, Autor autor)
        {
            Nombre = nombre;
            Genero = genero;
            Episodios = episodios;
            Lanzamiento = lanzamiento;
            Estado = estado;
            Estudio = estudio;
            Autor = autor;
        }
    }
}