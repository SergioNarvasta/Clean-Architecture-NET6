using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Services
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext _appDbContext;
        public EventoRepository(AppDbContext appDbContext) 
        {
           _appDbContext = appDbContext;
        }

        public async Task<List<Evento>> GetList()
        {
           return await _appDbContext.Eventos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Evento> GetById(int eventoId)
        {
            return await _appDbContext.Eventos
                 .Where(x => x.Id == eventoId)
                 .AsNoTracking()
                 .FirstAsync();
        }

        public async Task<bool> Create(Evento evento)
        {
            try
            {
                await _appDbContext.Eventos.AddAsync(evento);
                await _appDbContext.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Update(Evento evento)
        {
            try
            {
                _appDbContext.Eventos.Update(evento);
                await _appDbContext.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(int eventoId)
        {
            try
            {
                var evento = await _appDbContext.Eventos.FirstOrDefaultAsync(x => x.Id == eventoId);

                if (evento != null)
                {
                    _appDbContext.Eventos.Remove(evento);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


    }
}
