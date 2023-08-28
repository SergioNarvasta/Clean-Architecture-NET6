using Domain.Dto;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAccesoService
    {
        Task<Acceso> GetById(int accesoId);
        Task<Acceso> IniciarSesion(AccesoDto acceso);
    }
}
