using Domain.Dto;
using Domain.Entities;

namespace Infraestructure.Interfaces
{
    public interface IRolRepository
    {
        Task<bool> Create(Rol rol);
        Task<List<Rol>> GetList();
    }
}
