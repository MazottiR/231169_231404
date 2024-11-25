using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vendas.Models;

namespace vendas.Views
{
    public partial class FrmCidades : Form
    {
        Cidade c;
        public FrmCidades()
        {
            InitializeComponent();
        }


        void limpaControles()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Cidade();
            {
                marca = pesquisa;
            };
            dataGridView2.DataSource = c.Consultar();
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty) return;

            c = new Cidade();
            {
                marca = textBox2.Text;
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void dataGridView1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells["id"].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells["marca"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty) return;
            c = new Cidade();
            {
                id = int.Parse(textBox1.Text);
                marca = textBox2.Text;
            };
            c.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade();
                {
                    id = int.Parse(textBox1.Text);
                };
                c.Excuir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            carregarGrid(textBox4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells["id"].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells["nome"].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells["uf"].Value.ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
