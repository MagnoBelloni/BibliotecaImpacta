using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BibliotecaImpacta.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.BibliotecaDB>
    {
        private BibliotecaDB DB = new BibliotecaDB();
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        

        protected override void Seed(BibliotecaDB context)
        {
            context.Categorias.AddOrUpdate(c => c.Nome,
                new Categoria { Nome = "Ficção" },
                new Categoria { Nome = "Outros" }
            );

            context.Autores.AddOrUpdate(a => a.Nome,
                new Autor { Nome = "J.K. Rowling" },
                new Autor { Nome = "Autor Inicial" }
            );

            var autor = DB.Autores.Where(a => a.Nome.Equals("Autor Inicial")).FirstOrDefault();
            var categoria = DB.Categorias.Where(c => c.Nome.Equals("Outros")).FirstOrDefault();

            context.Livros.AddOrUpdate(new Livro
            {
                Nome = "Livro Inicial",
                AutorId = autor.Id,
                CategoriaId = categoria.Id,
                Descricao = "Livro de Teste",
                Quantidade = 5,
                TotalPaginas = 247
            });

            //context.Livros.AddOrUpdate(new Livro
            //{
            //    Nome = "Livro Inicial",
            //    AutorId = 2,
            //    CategoriaId = 2,
            //    Descricao = "Livro de Teste",
            //    Quantidade = 5,
            //    TotalPaginas = 247
            //});

        }
    }
}
