using System.Collections.Generic;
using System.Threading.Tasks;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Repositories
{
    public class FakeAutoresRepo : IAutoresRepository
    {
        public async Task<IEnumerable<AutorModel>> GetAutores()
        {
            var list = new List<AutorModel>();
            list.Add(new AutorModel{ AutorId = 1, Nombre = "pedro"});

            return list;
        }
    }
}