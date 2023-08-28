using Domain.Entities;
using Application.Interfaces;
using Infraestructure.Interfaces;

namespace Application.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        public RolService(IRolRepository rolRepository) 
        {
           _rolRepository = rolRepository;
        }

        public async Task<List<Rol>> GetList()
        {
            return await _rolRepository.GetList();
        }

        public async Task<bool> Create(Rol rol)
        {
            return await _rolRepository.Create(rol);
        }

    }
}
