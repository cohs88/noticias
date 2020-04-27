using System;
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
            AutorModel autor1 = new AutorModel{ AutorId = 1, Nombre = "Juan", Apellidos="Perez" };
            AutorModel autor2 = new AutorModel{ AutorId = 2, Nombre = "Carlos", Apellidos="Hernandez" };
            List<NoticiaModel> models = new List<NoticiaModel>();
            models.Add(new NoticiaModel{
                NoticiaId = 1, 
                Titulo ="Descontrol en Tijuana a causa del coronavirus", 
                Descripcion = "En los hospitales de la Secretaría de Salud en Tecate y Playas de Rosarito se presenta una ocupación del 54.16% y se tienen nueve ventiladores de los cuales solamente se usan dos", 
                CreatedAt = DateTime.Now, 
                Autor = autor1 });
            models.Add(new NoticiaModel{
                NoticiaId = 2, 
                Titulo ="La red sanitaria de Ciudad de México se enfrenta al riesgo de colapso", 
                Descripcion = "'Hay una sobredemanda de pacientes con síntomas', advierte la secretaria de Salud de la capital, en la frontera de los 3.000 contagios y los 250 fallecimientos",
                CreatedAt = DateTime.Now.AddDays(-2),
                Autor = autor2
                });
            models.Add(new NoticiaModel{NoticiaId = 3, 
                 Titulo ="Los agujeros del coronavirus en Venezuela", 
                 Descripcion = "Mientras Maduro exhibe como un éxito la gestión de la crisis, asociaciones médicas y la oposición denuncian la falta de transparencia ",
                 CreatedAt = DateTime.Now,
                 Autor = autor1 });

            return models;
        }
    }
}