using System.ComponentModel.DataAnnotations;

namespace AllEasy.API.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome{ get; set;}
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
    }
}