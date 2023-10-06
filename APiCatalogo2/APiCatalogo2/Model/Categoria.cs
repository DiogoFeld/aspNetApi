using System.Text.Json.Serialization;

namespace APiCatalogo2.Model
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }


        [JsonIgnore]
        public ICollection<Produto> Produtos { get;set; }

    }
}
