using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Interfaces;
using Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Services
{
    public class AccesoRepository : IAccesoRepository
    {
        private readonly AppDbContext _appDbContext;
        public AccesoRepository(AppDbContext appDbContext) 
        {
           _appDbContext = appDbContext;
        }

        public async Task<Acceso> IniciarSesion(AccesoDto acceso) => 
            await _appDbContext.Accesos
                .Include(a => a.UsuarioAsoc)
                .Where(x => x.Usuario == acceso.Usuario && x.Clave == acceso.Clave)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public async Task<Acceso> GetById(int accesoId) =>
            await _appDbContext.Accesos
                .Include(a => a.UsuarioAsoc)
                .Where(x => x.Id == accesoId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public async Task<bool> Create(Acceso acceso)
        {
            try
            {
                await _appDbContext.Accesos.AddAsync(acceso);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return false;
            }
        }



    }
}
