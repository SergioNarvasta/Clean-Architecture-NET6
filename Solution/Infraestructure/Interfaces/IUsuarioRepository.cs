
using Domain.Entities;

namespace Infraestructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> Create(Usuario usuario);
        Task<bool> Delete(int usuarioId);
        Task<Usuario> GetById(int usuarioId);
        Task<List<Usuario>> GetList();
        Task<bool> Update(Usuario usuario);
    }
}
