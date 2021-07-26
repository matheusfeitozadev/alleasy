using System.ComponentModel.DataAnnotations;

namespace AllEasy.API.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}