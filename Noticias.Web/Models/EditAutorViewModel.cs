using System.ComponentModel.DataAnnotations;

namespace Noticias.Web.Models
{
    public class EditAutorViewModel
    {
        [Required]
        public int AutorId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
    }
}