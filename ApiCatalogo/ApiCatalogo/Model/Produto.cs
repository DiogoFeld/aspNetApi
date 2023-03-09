using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ApiCatalogo.Model
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [MaxLength(80)]
        public string? Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Descricao { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco{ get; set; }
        [Required]
        [MaxLength(300)]
        public string? ImagemUrl { get; set; }
        public float Estoque{ get; set; }
        public DateTime DataCadastro{ get; set; }
        public int CategoriaID { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
