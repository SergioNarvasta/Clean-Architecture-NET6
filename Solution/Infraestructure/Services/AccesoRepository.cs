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
                .Where(x => x.Usuario == acceso.Usuario && x.Clave == acceso.Clave)
                .AsNoTracking()
                .FirstOrDefaultAsync();


    }
}
