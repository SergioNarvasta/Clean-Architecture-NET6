using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepository(AppDbContext appDbContext) 
        {
           _appDbContext = appDbContext;
        }

        public async Task<List<Usuario>> GetList()
        {
           return await _appDbContext.Usuarios
                .Where(x => x.Estado == Utils.Enums.Estados.Active)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario> GetById(int usuarioId)
        {
            return await _appDbContext.Usuarios
                 .Where(x => x.Id == usuarioId)
                 .AsNoTracking()
                 .FirstAsync();
        }

        public async Task Create(Usuario usuario)
        {
            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Usuario usuario)
        {
             _appDbContext.Usuarios.Update(usuario);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task Delete(int usuarioId)
        {
            await _appDbContext.Usuarios
                .Where(x => x.Id == usuarioId)
                .AsNoTracking()
                .ExecuteDeleteAsync();
        }

    }
}
