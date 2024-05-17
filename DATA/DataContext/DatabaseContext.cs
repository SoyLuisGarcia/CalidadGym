using HELPERS;
using Microsoft.EntityFrameworkCore;
using MODELS;

namespace DATA.DataContext
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Empleado> Empleados { get; set; }
    
        public virtual DbSet<Cliente> Clientes { get; set; }
    
        public virtual DbSet<Membresias> Membresias { get; set; }
        
        public virtual DbSet<PlanesEntrenamiento> PlanesEntrenamientos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuracion.CadenaConexxion,
                    builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
            }
        }
    }
}