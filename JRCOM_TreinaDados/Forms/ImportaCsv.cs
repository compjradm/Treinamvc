using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using JRCOM_TreinaDados.Model;

namespace JRCOM_TreinaDados
{
    public partial class frmImportaCsv : Form
    {
        public frmImportaCsv()
        {
            InitializeComponent();
        }

        private void BtnProcura_Click(object sender, EventArgs e)
        {
            if (AbreArquivoDialog.ShowDialog() == DialogResult.OK)
            {
                LblArquivo.Text = AbreArquivoDialog.FileName;
                BtnStart.Enabled = true;
            }
        }

        /*protected void th()
        {
            string linha;
            string[] dados;
            StreamReader rd = new StreamReader(LblArquivo.Text);
            do
            {
                linha = rd.ReadLine();
            } while (linha == "");
            do //implementar thread
            {
                linha = rd.ReadLine();
                if (linha != "")
                {
                    dados = linha.Split(',');
                    dataGridView1.Rows.Add(dados);
                }
            } while (rd.Peek() != -1);
        }*/

        private void BtnStart_Click(object sender, EventArgs e)
        {
            string linha;
            string[] divisor;
            progressBar1.MarqueeAnimationSpeed = 50;
            if (File.Exists(LblArquivo.Text))
            {
                StreamReader leitor = new StreamReader(LblArquivo.Text);
                try
                {
                    do
                    {
                        linha = leitor.ReadLine();
                        if (linha != "")
                        {
                            divisor = linha.Split(',');
                            for (int i = 0; i < divisor.GetLength(0); i++)
                            {
                                dataGridView1.Columns.Add(divisor[i], divisor[i]);
                            }
                        }
                    } while (linha == "");
                    do //implementar thread
                    {
                        linha = leitor.ReadLine();
                        if (linha != "")
                        {
                            divisor = linha.Split(',');
                            dataGridView1.Rows.Add(divisor);
                        }
                    } while (leitor.Peek() != -1);
                }
                catch (IndexOutOfRangeException err) { }
                catch (EndOfStreamException err) { }
                BtnStart.Enabled = false;
                BtnProcura.Enabled = false;
                BtnCancela.Enabled = true;
                BtnGrava.Enabled = true;
                progressBar1.MarqueeAnimationSpeed = 0;
                /*ThreadStart thread = new ThreadStart(th);
                Thread ITread = new Thread(thread);
                this.Cursor = Cursors.AppStarting;
                ITread.Start();*/
            }
        }

        private void BtnCancela_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja apagar todos os dados não salvos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                progressBar1.MarqueeAnimationSpeed = 50;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                BtnCancela.Enabled = false;
                BtnGrava.Enabled = false;
                BtnStart.Enabled = false;
                BtnProcura.Enabled = true;
                LblArquivo.Text = "Nenhum arquivo selecionado";
                progressBar1.MarqueeAnimationSpeed = 0;
            }
        }

        private void LblArquivo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private List<string> SanitizaValores(List<string> valores) { //função para trocar possíveis valores em string por suas respectivas FK
            switch (ComboTable.SelectedIndex)
            {
                case 0:
                    City city = new City();
                    if (valores.Count == 2) {
                        city.Cidade = valores.First<string>();
                        string temp = valores.ElementAt(2);
                        if (int.TryParse(temp, out int val))
                        {
                            city.IDEstado = val;
                        }
                        else {
                            ConBanco conecta = new ConBanco("bd", "usr", "pass");
                            Country country = new Country();
                            List<string>[] similares = conecta.Select("country", Country.ToStringTabelaLista(true), "country='" + temp);
                            try { city.IDEstado = Convert.ToInt32(similares[0].First<string>()); }
                            catch (IndexOutOfRangeException) {
                                MessageBox.Show("Nenhuma chave similar encontrada. Deixando como está.");
                            }
                            
                        }
                    }
                    break;
            }
            return valores;
        }

        private void BtnGrava_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja continuar?\n" + "Todos os dados da tabela serão salvos no Banco de Dados!", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataGridViewRow[] linhas = new DataGridViewRow[dataGridView1.Rows.Count];
                DataGridViewCell[] cell = new DataGridViewCell[dataGridView1.ColumnCount];
                List<string> ValoresLinha = new List<string>();
                string temp;
                ConBanco conBanco = new ConBanco("bd", "usr", "pass");
                City city = new City();
                progressBar1.MarqueeAnimationSpeed = 50;
                BtnCancela.Enabled = false;
                BtnGrava.Enabled = false;
                BtnStart.Enabled = false;
                BtnProcura.Enabled = false;
                dataGridView1.Rows.CopyTo(linhas, 0);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    linhas[i].Cells.CopyTo(cell, 0);
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        temp = Convert.ToString(cell[j].Value);
                        ValoresLinha.Add(temp);
                        ValoresLinha = SanitizaValores(ValoresLinha);
                    }
                    conBanco.InsereLinha("city", City.ToStringTabelaLista(), ValoresLinha);
                }

                BtnProcura.Enabled = true;
                LblArquivo.Text = "Nenhum arquivo selecionado";
                progressBar1.MarqueeAnimationSpeed = 0;
            }

        }
    }
}
