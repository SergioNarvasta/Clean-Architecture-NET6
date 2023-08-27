using Domain.Entities;
using Application.Interfaces;
using Infraestructure.Interfaces;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) 
        {
           _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> GetList()
        {
            return await _usuarioRepository.GetList();
        }

        public async Task<Usuario> GetById(int usuarioId)
        {
           return await _usuarioRepository.GetById(usuarioId);
        }

        public async Task Create(Usuario usuario)
        {
            await _usuarioRepository.Create(usuario);
        }

        public async Task Update(Usuario usuario)
        {
            await _usuarioRepository.Update(usuario);
        }

        public async Task Delete(int usuarioId)
        {
            await _usuarioRepository.Delete(usuarioId);
        }

    }
}
