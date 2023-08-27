
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task Create(Usuario usuario);
        Task Delete(int usuarioId);
        Task<Usuario> GetById(int usuarioId);
        Task<List<Usuario>> GetList();
        Task Update(Usuario usuario);
    }
}
