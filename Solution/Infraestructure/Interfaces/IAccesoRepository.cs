using Domain.Dto;
using Domain.Entities;

namespace Infraestructure.Interfaces
{
    public interface IAccesoRepository
    {
        Task<bool> Create(Acceso acceso);
        Task<Acceso> GetById(int accesoId);
        Task<Acceso> IniciarSesion(AccesoDto acceso);
    }
}
