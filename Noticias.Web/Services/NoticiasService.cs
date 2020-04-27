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

        public async Task CreateNoticia(EditNoticiaViewModel model)
        {
            await _noticiasRepository.CreateNoticia(model);
        }

        public async Task DeleteNoticia(int id)
        {
            await _noticiasRepository.DeleteNoticia(id);
        }

        public async Task<IEnumerable<NoticiasIndexViewModel>> GetHome()
        {
            var models = await _noticiasRepository.GetHome();
            return models.Select(m => new NoticiasIndexViewModel{
                NoticiaId = m.NoticiaId,
                Titulo = m.Titulo,
                Descripcion = m.Descripcion,
                FechaCreacion = m.FechaCreacion
            });
        }

        public async Task<EditNoticiaViewModel> GetNoticiaForEdit(int id)
        {
            NoticiaModel noticiaModel = await _noticiasRepository.GetNoticia(id);

            return new EditNoticiaViewModel
            {
                AutorId = noticiaModel.Autor.AutorId,
                NoticiaId = noticiaModel.NoticiaId,
                Titulo = noticiaModel.Titulo,
                Descripcion = noticiaModel.Descripcion,
                Contenido = noticiaModel.Contenido,
                FechaCreacion = noticiaModel.FechaCreacion
            };
        }

        public async Task<IEnumerable<NoticiaIndexAdminViewModel>> GetNoticiasAdmin()
        {
            var models = await _noticiasRepository.GetHome();

            return models.Select(n => new NoticiaIndexAdminViewModel
            {
                NoticiaId = n.NoticiaId,
                Titulo = n.Titulo,
                Descripcion = n.Descripcion,
                FechaCreacion = n.FechaCreacion,
                Autor = n.Autor?.NombreCompleto
            });
        }

        public async Task UpdateNoticia(EditNoticiaViewModel model)
        {
            await _noticiasRepository.UpdateNoticia(model);
        }
    }
}