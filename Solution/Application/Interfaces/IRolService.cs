using Domain.Dto;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRolService
    {
        Task<bool> Create(Rol rol);
        Task<List<Rol>> GetList();
    }
}
