using System.Collections.Generic;

namespace BibliotecaImpacta.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; internal set; }
    }
}