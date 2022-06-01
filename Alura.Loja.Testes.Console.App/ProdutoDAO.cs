using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.Console.App
{
    public class ProdutoDAO : IDisposable, IProdutoDAO
    {
        private NpgsqlConnection conexao;

        public ProdutoDAO()
        {
            this.conexao = new NpgsqlConnection("Server=localhost;Port=5432;User id=postgres;Password=didi240694;Database=LojaDB;");

            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        public void Adicionar(Produto p)
        {
            try
            {
                var insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Produtos (Nome, Categoria, Preco) VALUES (@nome, @categoria, @preco)";

                var paramNome = new NpgsqlParameter("nome", p.Nome);
                insertCmd.Parameters.Add(paramNome);

                var paramCategoria = new NpgsqlParameter("categoria", p.Categoria);
                insertCmd.Parameters.Add(paramCategoria);

                var paramPreco = new NpgsqlParameter("preco", p.PrecoUnitario);
                insertCmd.Parameters.Add(paramPreco);

                insertCmd.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public void Atualizar(Produto p)
        {
            try
            {
                var updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Produtos SET Nome = @nome, Categoria = @categoria, Preco = @preco WHERE Id = @id";

                var paramNome = new NpgsqlParameter("nome", p.Nome);
                var paramCategoria = new NpgsqlParameter("categoria", p.Categoria);
                var paramPreco = new NpgsqlParameter("preco", p.PrecoUnitario);
                var paramId = new NpgsqlParameter("id", p.Id);
                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramCategoria);
                updateCmd.Parameters.Add(paramPreco);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

            }
            catch (NpgsqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public void Remover(Produto p)
        {
            try
            {
                var deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Produtos WHERE Id = @id";

                var paramId = new NpgsqlParameter("id", p.Id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();

            }
            catch (NpgsqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public IList<Produto> Produtos()
        {
            var lista = new List<Produto>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Produtos";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Produto p = new Produto();
                p.Id = Convert.ToInt32(resultado["Id"]);
                p.Nome = Convert.ToString(resultado["Nome"]);
                p.Categoria = Convert.ToString(resultado["Categoria"]);
                p.PrecoUnitario = Convert.ToDouble(resultado["Preco"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}
