using Microsoft.EntityFrameworkCore;
using RegistroUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroUsuario.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Usuarios.db");
            
        }
    }
}
