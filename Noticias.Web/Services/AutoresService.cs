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

        public async Task CreateAutor(EditAutorViewModel autor)
        {
            await _autoresRepository.CreateAutor(autor);
        }

        public async Task DeleteAutor(int autorId)
        {
            await _autoresRepository.DeleteAutor(autorId);
        }

        public async Task<AutorModel> GetAutor(int autorId)
        {
            return await _autoresRepository.GetAutor(autorId);
        }

        public async Task<IEnumerable<AutorModel>> GetAutores()
        {
            return await _autoresRepository.GetAutores();
        }

        public async Task UpdateAutor(EditAutorViewModel autorViewModel)
        {
            await _autoresRepository.UpdateAutor(autorViewModel);
        }
    }
}