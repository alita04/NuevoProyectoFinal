using EMV.Domain.Entities;
using EMV.Domain.Entities.Samples;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using System.Drawing;
using EMV.Domain.Entities.Structures;
using EMV.DataAccess.FluentConfigurations;
using EMV.Domain.Entities.Variable;

namespace EMV.DataAccess.Contexts
{

    /// <summary>
    /// Definiendo la estructura de la base de datos 
    /// </summary>
    public class ApplicationContext : DbContext

    {
        #region Tables

        // DbSets para cada entidad
        public DbSet<Variable> Variables { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Sample> Samples { get; set; }



        #endregion



        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones
        /// </summary>
        public ApplicationContext()
        { }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="connectionString"> Cadena de conexion</param>
        public ApplicationContext(string connectionString)
        : base(GetOptions(connectionString)) { }

        private static DbContextOptions GetOptions(string connectionString)
        {

            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

        /// <summary>
        /// Inicializa un objeto<see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="options">Opciones del contexto</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source = EMVDB.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);


        }




    }
}
