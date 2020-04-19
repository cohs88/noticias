using System.Collections.Generic;
using System.Threading.Tasks;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Repositories
{
    public class FakeNoticiasRepository : INoticiasRepository
    {
        public async Task<IEnumerable<NoticiaModel>> GetHome()
        {
            List<NoticiaModel> models = new List<NoticiaModel>();
            models.Add(new NoticiaModel{NoticiaId = 1, Titulo ="Noticia 1", Descripcion = "Desc noticias 1" });

            return models;
        }
    }
}