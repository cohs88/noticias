using System.Collections.Generic;
using System.Threading.Tasks;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Services
{
    public class AutoresService : IAutoresService
    {
        private readonly IAutoresRepository _autoresRepository;

        public AutoresService(IAutoresRepository autoresRepository)
        {
            _autoresRepository = autoresRepository;
        }

        public async Task<IEnumerable<AutorModel>> GetAutores()
        {
            return await _autoresRepository.GetAutores();
        }
    }
}