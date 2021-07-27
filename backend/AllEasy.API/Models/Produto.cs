using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllEasy.API.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [ForeignKey("IDCATEGORIA")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        
        public string Nome{ get; set;}

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public string Ativo { get; set; }
    }
}