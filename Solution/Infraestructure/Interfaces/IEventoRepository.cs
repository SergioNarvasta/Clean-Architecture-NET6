using Domain.Dto;
using Domain.Entities;

namespace Infraestructure.Interfaces
{
    public interface IEventoRepository
    {
        Task<bool> Create(Evento evento);
        Task<bool> Delete(int eventoId);
        Task<Evento> GetById(int eventoId);
        Task<List<Evento>> GetList();
        Task<bool> Update(Evento evento);
    }
}
