using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyContext).Assembly);

            modelBuilder.Entity<Category>()
                .HasData(new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios"));
        }
    }
}
