using System;
using Microsoft.EntityFrameworkCore;
using Inventario.App.Dominio.Entidades;

namespace Inventario.App.Persistencia

{    
    public class AppContext : DbContext
    {
        //poner aqui los modelos un DbSet por cada clase o tabla
        public DbSet<Proveedor> proveedor{get; set;}

        //crear el deContext para la creación y conexión con la Base de Datos en SQLServer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder
           .UseSqlServer("Server=localhost; user id=sa; password=12345; Initial Catalog=invllantasDB;");            
            }
        }      

    }
}