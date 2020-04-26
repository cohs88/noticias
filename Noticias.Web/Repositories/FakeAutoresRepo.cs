using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Repositories
{
    public class FakeAutoresRepo : IAutoresRepository
    {
        public static List<AutorModel> Autores;
        public FakeAutoresRepo()
        {
            Autores = new List<AutorModel>();
            Autores.Add(new AutorModel{ AutorId = 1, Nombre = "pedro", Apellidos = "Ramirez"});
            Autores.Add(new AutorModel{ AutorId = 2, Nombre = "juan", Apellidos = "hernandez"});
            Autores.Add(new AutorModel{ AutorId = 3, Nombre = "manuel", Apellidos = "marquez"});
            Autores.Add(new AutorModel{ AutorId = 4, Nombre = "jose luis", Apellidos = "ramos"});
        }
        public Task<AutorModel> GetAutor(int autorId)
        {
            return Task.Run(() => Autores.FirstOrDefault(a => a.AutorId == autorId));
        }

        public async Task<IEnumerable<AutorModel>> GetAutores()
        {
            return Autores;
        }

        public async Task UpdateAutor(EditAutorViewModel autorViewModel)
        {
            
        }
    }
}