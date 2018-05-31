using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class FenixContext : DbContext
    {
        public FenixContext() :base("AzureConnection") //AzureConnection je naziv connection stringa u Web.config-u
        {

        }
        //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka
        /*public DbSet<Film> Film { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Videoteka> Videoteka { get; set; } */
        public DbSet<DummyClass> DummyClass { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}