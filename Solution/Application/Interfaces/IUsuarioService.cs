
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Create(Usuario usuario);
        Task<bool> Delete(int usuarioId);
        Task<Usuario> GetById(int usuarioId);
        Task<List<Usuario>> GetList();
        Task<bool> Update(Usuario usuario);
    }
}
