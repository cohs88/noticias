using System.Collections.Generic;
using System.Threading.Tasks;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Repositories
{
    public class AdoNoticiasRepository : INoticiasRepository
    {
        public Task CreateNoticia(EditNoticiaViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteNoticia(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<NoticiaModel>> GetHome()
        {
            throw new System.NotImplementedException();
        }

        public Task<NoticiaModel> GetNoticia(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateNoticia(EditNoticiaViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}