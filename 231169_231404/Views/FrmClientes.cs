﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vendas.Models;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace vendas.Views
{
    public partial class FrmClientes : Form
    {
        Cidade ci;
        Cliente cl;

        public FrmClientes()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            cboCidades.SelectedIndex = -1;
            txtUF.Clear();
            mskCPF.Clear();
            txtRenda.Clear();
            dtpDataNasc.Value = DateTime.Now;
            picFoto.ImageLocation = "";
            chkVenda.Checked = false;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ci = new Cidade();
            cboCidades.DataSource = ci.Consultar();
            cboCidades.DisplayMember = "nome";
            cboCidades.ValueMember = "id";

            limpaControles();
            carregarGrid("");

            dgvClientes.Columns["idCidade"].Visible = false;
            dvgClientes.Columns["foto"].Visible = false;
        }

        private void cboCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCidades.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCidades.SelectedItem;
                txtUF.Text = reg["uf"].ToString();
            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;
            cl = new Cliente()
            {
                nome = txtNome.Text,
                idCidade = (int)cboCidades.SelectedValue,
                dataNasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked
            };
            cl.Incluir();
            limpaControles();
            carregarGrid("");
        }

        private void dvgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgClientes.RowCount > 0)
            {
                txtID.Text = dvgClientes.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dvgClientes.CurrentRow.Cells["nome"].Value.ToString();
                cboCidades.Text = dvgClientes.CurrentRow.Cells["cidade"].Value.ToString();
                txtUF.Text = dvgClientes.CurrentRow.Cells["uf"].Value.ToString();
                chkVenda.Checked = (bool)dvgClientes.CurrentRow.Cells["venda"].Value;
                mskCPF.Text = dvgClientes.CurrentRow.Cells["cpf"].Value.ToString();
                dtpDataNasc.Text = dvgClientes.CurrentRow.Cells["dataNasc"].Value.ToString();
                txtRenda.Text = dvgClientes.CurrentRow.Cells["renda"].Value.ToString();
                picFoto.ImageLocation = dvgClientes.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            cl = new Cliente()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                idCidade = (int)cboCidades.SelectedValue,
                dataNasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked
            };
            cl.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir o cliente?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cl = new Cliente()
                {
                    id = int.Parse(txtID.Text)
                };
                cl.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
