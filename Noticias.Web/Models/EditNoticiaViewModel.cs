using System;
using System.ComponentModel.DataAnnotations;

namespace Noticias.Web.Models
{
    public class EditNoticiaViewModel
    {
        public int NoticiaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Contenido { get; set; }
        public int AutorId { get; set; }
    }
}