using System.Collections.Generic;
using System.Threading.Tasks;
using Noticias.Web.Models;

namespace Noticias.Web.Interfaces
{
    public interface IAutoresService
    {
        Task<IEnumerable<AutorModel>> GetAutores();
        Task<AutorModel> GetAutor(int autorId);
        Task UpdateAutor(EditAutorViewModel autorViewModel);
    }
}