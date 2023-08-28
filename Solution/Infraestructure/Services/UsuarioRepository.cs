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

        public async Task<Usuario> Create(Usuario usuario)
        {
            try
            {
                await _appDbContext.Usuarios.AddAsync(usuario);
                await _appDbContext.SaveChangesAsync();
                return usuario; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return null;
            }
        }
        

        public async Task<bool> Update(Usuario usuario)
        {
            try
            {
                _appDbContext.Usuarios.Update(usuario);
                await _appDbContext.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(int usuarioId)
        {
            try
            {
                var usuario = await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);

                if (usuario != null)
                {
                    _appDbContext.Usuarios.Remove(usuario);
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
