using Domain.Dto;
using Domain.Entities;

namespace Infraestructure.Interfaces
{
    public interface IAccesoRepository
    {
        Task<Acceso> IniciarSesion(AccesoDto acceso);
    }
}
