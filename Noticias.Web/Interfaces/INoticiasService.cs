using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Noticias.Web.Models;

namespace Noticias.Web.Interfaces
{
    public interface INoticiasService
    {
        Task<IEnumerable<NoticiasIndexViewModel>> GetHome();
        Task<IEnumerable<NoticiaIndexAdminViewModel>> GetNoticiasAdmin();
        Task CreateNoticia(EditNoticiaViewModel model);
        Task<EditNoticiaViewModel> GetNoticiaForEdit(int id);
        Task UpdateNoticia(EditNoticiaViewModel model);
    }
}