using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cartefact.Models
{
    public class Entities : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Rental> Rental { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>()
                .HasKey(s => s.Id) //on définit la clé primaire
                .Property(s => s.Id);

            modelBuilder.Entity<Car>()
                .HasKey(s => s.Id) //on définit la clé primaire
                .Property(s => s.Id);

            modelBuilder.Entity<Rental>()
               .HasKey(s => s.Id) //on définit la clé primaire
               .Property(s => s.Id);

        }
    }
}