using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        /*
         Add-Migration -Context Infraestructure.Data.AppDbContext -name init_01
         Update-Database -Verbose -Context AppDbContext
         
         Remove-Migration -Context AppDbContext
       */
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SedeOlimpica> SedesOlimpicas { get; set; }
        public DbSet<ComplejoDeportivo> ComplejosDeportivos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Polideportivo> Polideportivos { get; set; }
        public DbSet<Deporte> Deportes { get; set; }
        public DbSet<AreaDeportiva> AreasDeportivas { get; set; }
        public DbSet<DeporteEspecifico> Especificos { get; set; }
        public DbSet<Equipamiento> Equipamientos { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
