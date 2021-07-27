using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllEasy.API.Models
{
    [Table("CATEGORIA")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string Descricao { get; set; }

        public string Ativo { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}