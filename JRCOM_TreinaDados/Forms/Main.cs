using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JRCOM_TreinaDados
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CadastroCliente cli = new CadastroCliente();
            cli.ShowDialog();
        }

        private void endreçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro_end ender = new Cadastro_end();
            ender.ShowDialog();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro_Cidade cid = new Cadastro_Cidade();
            cid.ShowDialog();
        }

        private void estadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro_estado est = new Cadastro_estado();
            est.ShowDialog();
        }

        private void controleDeFilmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro_filme filme = new Cadastro_filme();
            filme.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filme_categorias categorias = new Filme_categorias();
            categorias.ShowDialog();
        }

        private void idiomaasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filme_idioma idioma = new Filme_idioma();
            idioma.ShowDialog();
        }

        private void atoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filme_Atores atores = new Filme_Atores();
            atores.ShowDialog();
        }

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locacoes loc = new Locacoes();
            loc.ShowDialog();
        }

        private void pagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagamentos pag = new Pagamentos();
            pag.ShowDialog();
        }

        private void lojasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lojas lojas = new Lojas();
            lojas.ShowDialog();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcionarios func = new Funcionarios();
            func.ShowDialog();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }
    }
}
