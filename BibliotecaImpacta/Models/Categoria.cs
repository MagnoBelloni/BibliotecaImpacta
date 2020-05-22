using System.ComponentModel;

namespace BibliotecaImpacta.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [DisplayName("Nome da Categoria")]
        public string Nome { get; set; }
    }
}