using BibliotecaImpacta.Models;
using System.Data.Entity.Migrations;

namespace BibliotecaImpacta.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.BibliotecaDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        

        protected override void Seed(DataContext.BibliotecaDB context)
        {
            context.Categorias.AddOrUpdate(c => c.Nome,
                new Categoria { Nome = "Ficção" },
                new Categoria { Nome = "Outros" }
            );

            context.Autores.AddOrUpdate(a => a.Nome,
                new Autor { Nome = "J.K. Rowling" },
                new Autor { Nome = "Autor Inicial" }
            );

            context.Livros.AddOrUpdate(new Livro
            {
                Nome = "Livro Inicial",
                AutorId = 2,
                CategoriaId = 2,
                Descricao = "Livro de Teste",
                Quantidade = 5,
                TotalPaginas = 247
            });

        }
    }
}
