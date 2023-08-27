
using Domain.Entities;

namespace Infraestructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Create(Usuario usuario);
        Task Delete(int usuarioId);
        Task<Usuario> GetById(int usuarioId);
        Task<List<Usuario>> GetList();
        Task Update(Usuario usuario);
    }
}
