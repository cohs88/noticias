using System.Collections.Generic;
using System.Threading.Tasks;
using Noticias.Web.Models;

namespace Noticias.Web.Interfaces
{
    public interface IAutoresService
    {
        Task<IEnumerable<AutorModel>> GetAutores();
    }
}