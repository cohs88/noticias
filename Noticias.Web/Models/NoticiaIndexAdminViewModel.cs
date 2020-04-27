using System;

namespace Noticias.Web.Models
{
    public class NoticiaIndexAdminViewModel
    {
        public int NoticiaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Autor { get; set; }
    }
}