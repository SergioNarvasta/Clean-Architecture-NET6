using Domain.Dto;
using Domain.Entities;

namespace Infraestructure.Interfaces
{
    public interface IAccesoRepository
    {
        Task<Acceso> GetById(int accesoId);
        Task<Acceso> IniciarSesion(AccesoDto acceso);
    }
}
