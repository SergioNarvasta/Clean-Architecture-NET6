using Domain.Entities;


namespace Application.Interfaces
{
    public interface IEventoService
    {
        Task<bool> Create(Evento evento);
        Task<bool> Delete(int eventoId);
        Task<Evento> GetById(int eventoId);
        Task<List<Evento>> GetList();
        Task<bool> Update(Evento evento);
    }
}
