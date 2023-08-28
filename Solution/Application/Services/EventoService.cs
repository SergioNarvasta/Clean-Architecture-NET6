using Domain.Entities;
using Application.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Data;

namespace Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        public EventoService(IEventoRepository eventoRepository) 
        {
           _eventoRepository = eventoRepository;
        }

        public async Task<List<Evento>> GetList()
        {
            return await _eventoRepository.GetList();
        }

        public async Task<Evento> GetById(int eventoId)
        {
            return await _eventoRepository.GetById(eventoId);
        }

        public async Task<bool> Create(Evento evento)
        {
            return await _eventoRepository.Create(evento);
        }

        public async Task<bool> Update(Evento evento)
        {
            return await _eventoRepository.Update(evento);
        }

        public async Task<bool> Delete(int eventoId)
        {
           return await _eventoRepository.Delete(eventoId);
        }

    }
}
