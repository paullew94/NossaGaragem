using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class VeiculoRepository
    {
        public int Inserir(Veiculo veiculo)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"INSERT INTO veiculos (modelo,id_categoria,valor) OUTPUT INSERTED.ID VALUES(@MODELO,@ID_CATEGORIA,@VALOR)";
            comando.Parameters.AddWithValue("@MODELO",veiculo.Modelo);
            comando.Parameters.AddWithValue("@ID_CATEGORIA",veiculo.IdCategoria);
            comando.Parameters.AddWithValue("@VALOR",veiculo.Valor);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public List<Veiculo>ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText= @"SELECT
veiculos.id AS'VeiculoId',
veiculos.modelo AS'VeiculoModelo',
veiculos.id_categoria AS 'VeiculoIdCategoria',
veiculos.valor AS'VeiculoValor',
categorias.nome AS'CategoriaNome'
FROM veiculos
INNER JOIN categorias ON(veiculos.id_categoria=categorias.id)";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            List<Veiculo> veiculos = new List<Veiculo>();
            foreach(DataRow linha in tabela.Rows)
            {
                Veiculo veiculo = new Veiculo();
                veiculo.Id = Convert.ToInt32(linha["VeiculoId"]);
                veiculo.Modelo = linha["VeiculoModelo"].ToString();
                veiculo.Valor = Convert.ToDecimal(linha["VeiculoValor"]);
                veiculo.IdCategoria = Convert.ToInt32(linha["VeiculoIdCategoria"]);
                veiculo.Categoria = new Categoria();
                veiculo.Categoria.Nome = linha["CategoriaNome"].ToString();
                veiculos.Add(veiculo);
            }
            return veiculos;
        }
    }
    
    
}
