using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Data
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoDeAlquiler> EstadoDeAlquileres { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {
        }
        public LibreriaContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.ClienteId);

                entity.Property(c => c.DNI).HasMaxLength(10).IsRequired();
                entity.Property(c => c.Nombre).HasMaxLength(45).IsRequired();
                entity.Property(c => c.Apellido).HasMaxLength(45).IsRequired();
                entity.Property(c => c.Email).HasMaxLength(45).IsRequired();
                entity.ToTable("Cliente");
            });
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(l => l.ISBN);
                entity.Property(l => l.ISBN).HasMaxLength(50).IsRequired();
                entity.Property(l => l.Titulo).HasMaxLength(45).IsRequired();
                entity.Property(l => l.Autor).HasMaxLength(45).IsRequired();
                entity.Property(l => l.Editorial).HasMaxLength(45).IsRequired();
                entity.Property(l => l.Edicion).HasMaxLength(45).IsRequired();
                entity.Property(l => l.Stock).HasMaxLength(10);
                entity.Property(l => l.Imagen).HasMaxLength(45).IsRequired();
                entity.ToTable("Libros");
                entity.HasData(
                     new Libro { ISBN = "9788478290598", Titulo = "Patrones de Diseño", Autor = "Erich Gamma", Editorial = "ADDISON WESLEY", Edicion = "2002", Stock = 10, Imagen = "https://bit.ly/3njK38N" },
                     new Libro { ISBN = "9788441526372", Titulo = "Aprende SQL", Autor = "Beaulieu Alan", Editorial = "ANAYA MULTIMEDIA", Edicion = "2009", Stock = 10, Imagen = "https://bit.ly/3tWVIhy" },
                     new Libro { ISBN = "9788437604947", Titulo = "Cien Años de Soledad", Autor = "Gabriel Garcia Marquez", Editorial = "Ediciones Cátedra", Edicion = "2007", Stock = 10, Imagen = "https://bit.ly/3HMVDmm" },
                     new Libro { ISBN = "9789504935575", Titulo = "Palabras Cruzadas", Autor = "Gabriel Rolon", Editorial = "Planeta Publishing", Edicion = "2013", Stock = 10, Imagen = "https://bit.ly/3nc2jB1" },
                     new Libro { ISBN = "9789506444808", Titulo = "El Visitante", Autor = "King Stephen", Editorial = "Plaza & Janes Editores", Edicion = "2018", Stock = 10, Imagen = "https://bit.ly/3zW9ViN" },
                     new Libro { ISBN = "9782409014932", Titulo = "SQL 'Los fundamentos del lenguaje' ", Autor = "Godoc Eric", Editorial = "Eni", Edicion = "2018", Stock = 10, Imagen = "https://bit.ly/3Nq8w7m" },
                     new Libro { ISBN = "9789506445386", Titulo = "La Sangre Manda", Autor = "King Stephen", Editorial = "Plaza & Janes Editores", Edicion = "2020", Stock = 10, Imagen = "https://bit.ly/3xNnyyc" },
                     new Libro { ISBN = "9789504970934", Titulo = "El duelo", Autor = "Gabriel Rolon", Editorial = "Planeta Publishing", Edicion = "2021", Stock = 10, Imagen = "https://bit.ly/3A2pxBu" },
                     new Libro { ISBN = "9786125020024", Titulo = "La Buena Suerte", Autor = "Montero Rosa", Editorial = "Alfaguara", Edicion = "2021", Stock = 10, Imagen = "https://bit.ly/3Ojwt1j" },
                     new Libro { ISBN = "9788417289362", Titulo = "Programación concurrente y en tiempo real", Autor = "Capel Tuñon Manuel I", Editorial = "GARCETA GRUPO EDITORIAL", Edicion = "2022", Stock = 10, Imagen = "https://bit.ly/3ygRfsU" }
                     );
            });

            modelBuilder.Entity<EstadoDeAlquiler>(entity =>
            {
                entity.HasKey(e => e.EstadoDeAlquilerId);
                entity.Property(e => e.Descripcion).HasMaxLength(45).IsRequired();
                entity.ToTable("EstadoDeAlquileres");
                entity.HasData(
                new EstadoDeAlquiler { EstadoDeAlquilerId = 1, Descripcion = "Reservado" },
                new EstadoDeAlquiler { EstadoDeAlquilerId = 2, Descripcion = "Alquilado" },
                new EstadoDeAlquiler { EstadoDeAlquilerId = 3, Descripcion = "Cancelado" }
                );
            });

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.ToTable("Alquileres");
                entity.HasKey(a => a.Id);

                entity.Property(a => a.ISBN).HasMaxLength(50).IsRequired();
                entity.HasOne(c => c.Cliente).WithMany(c => c.AlquilerNavigator).HasForeignKey(c => c.ClienteId);
                entity.HasOne(l => l.Libros).WithMany(a => a.AlquilerNavigator).HasForeignKey(l => l.ISBN);
                entity.HasOne(e => e.EstadoDeAlquiler).WithMany(a => a.AlquilerNavigator).HasForeignKey(e => e.EstadoDeAlquilerId);
            });
        }
    }
}