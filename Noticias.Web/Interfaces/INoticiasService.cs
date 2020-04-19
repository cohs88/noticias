using System.Collections;
using System.Collections.Generic;

namespace Noticias.Web.Interfaces
{
    public interface INoticiasService
    {
        IEnumerable<Models.NoticiasIndexViewModel> GetIndex();    
    }
}