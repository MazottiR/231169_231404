using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace vendas
{
    public class Banco
    {
        public static MySqlConnection Conexao;

        public static MySqlCommand Comando;

        public static MySqlDataAdapter Adaptador;

        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port3307;uid=root;pwd=etecjau");

                Conexao.Open();
            }
            catch (Exception e)
            {
                {
                    MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();

                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas;", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS cidades; " + "(id integer auto_increment primarykey, "
                    + "nome char(40), " + "uf char(02))", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS marcas; " + "(id integer auto_increment primarykey, "
                    + "marca char(40), ", Conexao);

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS categorias; " + "(id integer auto_increment primarykey, "
                    + "categoria char(40), ", Conexao);

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS clientes; " + "(id integer auto_increment primarykey, "
                    + "nome varchar(40), " +
                    "idCidade integer, " +
                    "dataNasc date, " +
                    "renda decimal(10,2), " +
                    "cpf char(14), " +
                    "foto varchar(100), " +
                    "venda boolean)", Conexao);

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS produtos; " + "(id integer auto_increment primarykey, "
                    + "descricao char(40), " + "idCategoria integer, " + "idMarca integer, " + "estoque decimal(10,3), " + "valorVenda decimal(10,2), "
                    + "foto varchar(100))", Conexao);

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaCab; " + "(id integer auto_increment primarykey, "
                    + "idCliente int, " +
                    "data date, " +
                    "total decimal(10,2))", Conexao);

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaCab; " + "(id integer auto_increment primarykey, "
                    + "idVendaCab int, " +
                    "idProduto int, " +
                    "qtde decimal(10,3))" + 
                    "valorUnitario decimal(10,2)", Conexao);
                

                Comando.ExecuteNonQuery();

                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


