using System;
using System.Text.Json.Serialization;

namespace APiCatalogo2.Model
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome  { get; set; }
        public string? Descricao  { get; set; }
        public decimal Preco { get; set; }
        public string? imagem { get; set; }
        public DateTime DataCompra{ get; set; }
        public int Estoque { get; set; }

        public int CaregoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; }

    }
}
