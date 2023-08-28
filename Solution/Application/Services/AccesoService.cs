using Application.Interfaces;
using Domain.Dto;
using Domain.Entities;
using Infraestructure.Interfaces;

namespace Application.Services
{
    public class AccesoService : IAccesoService
    {
        private readonly IAccesoRepository _accesoRepository;
        public AccesoService(IAccesoRepository accesoRepository) {
        _accesoRepository = accesoRepository;
        }

        public async Task<Acceso> IniciarSesion(AccesoDto acceso) =>
            await _accesoRepository.IniciarSesion(acceso);

        public async Task<Acceso> GetById(int accesoId) =>
            await _accesoRepository.GetById(accesoId);


    }
}
