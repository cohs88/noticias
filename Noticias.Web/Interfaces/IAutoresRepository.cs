using System.Collections.Generic;
using System.Threading.Tasks;
using Noticias.Web.Models;

namespace Noticias.Web.Interfaces
{
    public interface IAutoresRepository
    {
        Task<IEnumerable<AutorModel>> GetAutores();
        Task<AutorModel> GetAutor(int autorId);
        Task UpdateAutor(EditAutorViewModel autorViewModel);
        Task DeleteAutor(int autorId);
        Task CreateAutor(EditAutorViewModel autor);
    }
}