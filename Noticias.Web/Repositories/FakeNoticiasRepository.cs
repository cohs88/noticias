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
            models.Add(new NoticiaModel{NoticiaId = 2, Titulo ="La red sanitaria de Ciudad de México se enfrenta al riesgo de colapso", Descripcion = "'Hay una sobredemanda de pacientes con síntomas', advierte la secretaria de Salud de la capital, en la frontera de los 3.000 contagios y los 250 fallecimientos" });
            models.Add(new NoticiaModel{NoticiaId = 3, Titulo ="Los agujeros del coronavirus en Venezuela", Descripcion = "Mientras Maduro exhibe como un éxito la gestión de la crisis, asociaciones médicas y la oposición denuncian la falta de transparencia " });

            return models;
        }
    }
}