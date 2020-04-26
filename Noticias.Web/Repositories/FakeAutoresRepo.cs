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
            list.Add(new AutorModel{ AutorId = 1, Nombre = "pedro", Apellidos = "Ramirez"});
            list.Add(new AutorModel{ AutorId = 2, Nombre = "juan", Apellidos = "hernandez"});
            list.Add(new AutorModel{ AutorId = 3, Nombre = "manuel", Apellidos = "marquez"});
            list.Add(new AutorModel{ AutorId = 4, Nombre = "jose luis", Apellidos = "ramos"});

            return list;
        }
    }
}