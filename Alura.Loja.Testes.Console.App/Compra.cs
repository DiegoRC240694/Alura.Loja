using Alura.Loja.Testes.Console.App;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Compra
    {
        public int Id { get; set; } 
        public int Quantidade { get;  set; }
        public Produto? Produto { get;  set; }
        public double Preco { get;  set; }

        public override string ToString()
        {
            return $"Compra de {this.Quantidade} {this.Produto.Unidade} do produto {this.Produto.Nome} a R$ {this.Preco}";
        }
        //public Compra()
        //{
        //}
    }
}