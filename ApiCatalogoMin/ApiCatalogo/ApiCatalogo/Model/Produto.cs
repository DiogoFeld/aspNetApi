namespace ApiCatalogo.Model
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; } 
        public string? Imagem{ get; set; }
        public int Estoque { get; set; }

        public int CategoriaId { get;set; }
        public Categoria? Categoria { get; set; }


    }
}
