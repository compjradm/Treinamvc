﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRCOM_TreinaDados.Model;

namespace JRCOM_TreinaDados
{
    public partial class Cadastro_Cidade : Form
    {
        ConBanco BD = new ConBanco("sakila","postgre","");
        City DadosCidade = new City();
        String Estado_estenso;
        int IdEstado;
        bool novo;
        int reg;
        public Cadastro_Cidade()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtId.Text = String.Empty;
            TxtCidade.Text = String.Empty;
            TxtEstado.Text = String.Empty;
            novo = true;
        }

        private void Cadastro_Cidade_Load(object sender, EventArgs e)
        {
            novo = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DadosCidade.Cidade = TxtCidade.Text;
            DadosCidade.IDEstado = IdEstado;
            if (novo) {
                BD.InsereLinha("city", City.ToStringTabelaLista(), DadosCidade.ToStringValoresLista());
            }
            else
            {
                BD.UpdateLine("city",City.ToStringTabelaLista(), DadosCidade.ToStringValoresLista(),"id_city="+reg);
            }
            novo = false;
        }

        private void BtnApaga_Click(object sender, EventArgs e)
        {
            if (novo)
                MessageBox.Show("Nenhum registro selecionado para exclusão!");
            else
            {
                BD.ApagaLinha("city","id_city="+reg);
            }
        }

        private void BtnPrimeiro_Click(object sender, EventArgs e)
        {
            List<string>[] dados;
            dados = BD.Select("city",City.ToStringTabelaLista(true), "id_city=1");
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            List<string>[] dados;
            dados = BD.Select("city", City.ToStringTabelaLista(true), "id_city=1");
        }

        private void BtnUltimo_Click(object sender, EventArgs e)
        {
            List<string>[] dados;
            dados = BD.Select("city", City.ToStringTabelaLista(true), "id_city=1");
        }

        private void BtnProx_Click(object sender, EventArgs e)
        {
            List<string>[] dados;
            dados = BD.Select("city", City.ToStringTabelaLista(true), "id_city=1");
        }
    }
}
