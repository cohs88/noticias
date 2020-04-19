using System;

namespace Noticias.Web.Models
{
    public class NoticiaModel
    {
        public int NoticiaId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public AutorModel Autor { get; set; }
    }
}