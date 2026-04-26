using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace Control_Gastos
{
    public class gastosContext : DbContext
    {
        public DbSet<Gasto> Gastos
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=ControlGastosDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
