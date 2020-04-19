namespace Noticias.Web.Models
{
    public class AutorModel
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto => $"{Nombre}, {Apellidos}";
    }
}