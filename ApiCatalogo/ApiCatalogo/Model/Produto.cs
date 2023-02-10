using System;
using System.Reflection.Metadata.Ecma335;

namespace ApiCatalogo.Model
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco{ get; set; }
        public int ImagemUrl { get; set; }
        public int Estoque{ get; set; }
        public DateTime DataCadastro{ get; set; }
    }
}
