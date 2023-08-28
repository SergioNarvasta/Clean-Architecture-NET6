using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Services
{
    public class RolRepository : IRolRepository
    {
        private readonly AppDbContext _appDbContext;
        public RolRepository(AppDbContext appDbContext) 
        {
           _appDbContext = appDbContext;
        }

        public async Task<List<Rol>> GetList()
        {
           return await _appDbContext.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> Create(Rol rol)
        {
            try
            {
                await _appDbContext.Roles.AddAsync(rol);
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
