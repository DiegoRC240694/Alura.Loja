using Alura.Loja.Testes.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.Console.App
{
    public class Produto
    {
        public int Id { get;  set; }
        public string? Nome { get;  set; }
        public string? Categoria { get;  set; }
        public double PrecoUnitario { get;  set; }
        public string? Unidade { get; set; }
        public IList<PromocaoProduto>? Promocoes { get; set; }
        public IList<Compra>? Compras { get; set; }

        public override string ToString()
        {
            return $"Produto:  { this.Id}, {this.Nome}, {this.Categoria}, {this.PrecoUnitario}";
        }

        //public Produto(string Nome, string Categoria, double Preco)
        //{
        //    if (Nome == "" || Nome == null)
        //    {
        //        throw new ArgumentException("O argumento nome deve ser preenchido.", nameof(Nome));
        //    }
        //    if (Categoria == "" || Categoria == null)
        //    {
        //        throw new ArgumentException("O argumento categoria deve ser preenchido.", nameof(Categoria));
        //    }
        //    if (Preco <= 0)
        //    {
        //        throw new ArgumentException("O argumento preco deve ser preenchido.", nameof(Preco));
        //    }
        //    nome = Nome;
        //    categoria = Categoria;
        //    preco = Preco;
        //}

        //public Produto()
        //{

        //}
    }
}
