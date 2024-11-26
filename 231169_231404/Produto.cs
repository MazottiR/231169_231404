using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vendas.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string descricao { get; set; }
        public string idCategoria { get; set; }
        public string idMarca { get; set; }
        public decimal estoque { get; set; }
        public decimal valorVenda { get; set; }
        public string foto { get; set; }

        public DataTable Consultar()
        {
            try
            {
                Banco.Comando = new MySqlCommand("SELECT p.*, m.marca, " +
                    "c.categoria FROM Produtos p inner join Marcas m on (m.id = p.idMarca) " +
                    "inner join Categorias c on (c.id = p.idCategoria)" + 
                    "where p.descricao like @descricao order by p.descricao", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
