using Microsoft.EntityFrameworkCore;
using PS.Template.Domain.Models;
using PS.Template.Domain.Settings;

namespace PS.Template.AccessData.DBContext
{
    public partial class ProyectoSoftwareContext : DbContext
    {
        public ProyectoSoftwareContext()
        {
        }

        public ProyectoSoftwareContext(DbContextOptions<ProyectoSoftwareContext> options)
            : base(options)
        {
        }

        public DbSet<Features> features { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Follow> follows { get; set; }

        //Agregar las otras tablas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            new SettingsFollow(modelBuilder.Entity<Follow>());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
