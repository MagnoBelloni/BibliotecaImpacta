using BibliotecaImpacta.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BibliotecaImpacta.DataContext
{
    public class BibliotecaDB : DbContext
    {
        //public BibliotecaDB() : base("BibliotecaDB")
        //{

        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}