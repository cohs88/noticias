using System.Collections.Generic;

namespace Noticias.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<NoticiasIndexViewModel> Noticias { get; set; }
    }
}