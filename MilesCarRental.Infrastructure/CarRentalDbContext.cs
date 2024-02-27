using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using MilesCarRental.Infrastructure.Entities;
using System.Xml;

namespace MilesCarRental.Infrastructure
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> option) : base(option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                SqlServerOptionsExtension CnxOptios = (SqlServerOptionsExtension)optionsBuilder.Options.Extensions.OfType<SqlServerOptionsExtension>().First();
                string cnx = CnxOptios.ConnectionString;

                if (cnx != null)
                    optionsBuilder.UseSqlServer(cnx).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Agregamos datos a la tablas maestras.
            modelBuilder.Entity<MarcaEntity>().HasData(
                new MarcaEntity { Id = 1, Descripcion = "Renault" },
                new MarcaEntity { Id = 2, Descripcion = "Chevrolet" },
                new MarcaEntity { Id = 3, Descripcion = "Mazda" },
                new MarcaEntity { Id = 4, Descripcion = "Kia" }
            );

            modelBuilder.Entity<LocalidadEntity>().HasData(
                 new LocalidadEntity { Id = 1, Nombre = "Sede Principal", Direccion = "Carrera 21", Telefono = "3012584679" },
                new LocalidadEntity { Id = 2, Nombre = "Sede Bogota", Direccion = "Carrera 200", Telefono = "3012584613" },
                new LocalidadEntity { Id = 3, Nombre = "Sede Medellin Belen", Direccion = " Carrera 80", Telefono = "3005681285" },
                new LocalidadEntity { Id = 4, Nombre = "Sede Bogota la 93", Direccion = "Calle 93", Telefono = "3128964352" }
            );

            modelBuilder.Entity<VehiculoEntity>().HasData(
                new VehiculoEntity { Id = 1, Placa = "AAQ 365", Modelo = 2016, IdMarca = 1, IdLocalidadActual = 1},
                new VehiculoEntity { Id = 2, Placa = "TIP 452", Modelo = 2021, IdMarca = 1, IdLocalidadActual = 3 },
                new VehiculoEntity { Id = 3, Placa = "UTG 123", Modelo = 2022, IdMarca = 2, IdLocalidadActual = 4 },
                new VehiculoEntity { Id = 4, Placa = "PRR 759", Modelo = 2015, IdMarca = 3, IdLocalidadActual = 1 }
            );

            modelBuilder.Entity<ClienteEntity>().HasData(
                new ClienteEntity { Id = 1, Documento = "1128436325", Nombre = "Jeison Cañas", Telefono = "3137653881", Direccion = "Carrera 42A", Email = "jeison9101@gmail.com" },
                new ClienteEntity { Id = 2, Documento = "1023468549", Nombre = "Carlos Perez", Telefono = "3012568423", Direccion = "Calle 81", Email = "carlos@example.com" },
                new ClienteEntity { Id = 3, Documento = "1165794321", Nombre = "Catalina Cifuentes", Telefono = "3104526981", Direccion = "Av 34 sur", Email = "cata21@example.com" }
            );
        }

        public DbSet<MarcaEntity> Marcas { get; set; }
        public DbSet<LocalidadEntity> Localidades { get; set; }
        public DbSet<VehiculoEntity> Vehiculos { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<AlquilerEntity> Alquileres { get; set; }
    }
}