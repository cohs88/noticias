using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Services
{
    public class NoticiasService : INoticiasService
    {
        private readonly INoticiasRepository _noticiasRepository;
        public NoticiasService(INoticiasRepository noticiasRepository)
        {
            _noticiasRepository = noticiasRepository;
        }

        public async Task<IEnumerable<NoticiasIndexViewModel>> GetHome()
        {
            var models = await _noticiasRepository.GetHome();
            return models.Select(m => new NoticiasIndexViewModel{
                NoticiaId = m.NoticiaId,
                Titulo = m.Titulo,
                Descripcion = m.Descripcion
            });
        }
    }
}