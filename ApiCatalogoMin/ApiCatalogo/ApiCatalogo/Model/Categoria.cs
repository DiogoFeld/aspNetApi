namespace ApiCatalogo.Model
{
    public class Categoria
    {
        public int ProdutoId { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }

        public ICollection<Produto> produtos { get; set; }

    }
}
