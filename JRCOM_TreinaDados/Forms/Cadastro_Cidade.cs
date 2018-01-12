using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRCOM_TreinaDados.Model;

namespace JRCOM_TreinaDados
{
    public partial class Cadastro_Cidade : Form
    {
		ConBanco BD = new ConBanco("sakila", "postgre", "");
		City DadosCidade = new City();
		String Estado_estenso;
		int IdEstado;
		bool novo;
		int reg = 0;
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
			if (novo)
			{
				BD.InsereLinha("city", DadosCidade.ToStringTabelaLista(), DadosCidade.ToStringValoresLista());
			}
			else
			{
				BD.UpdateLine("city", DadosCidade.ToStringTabelaLista(), DadosCidade.ToStringValoresLista(), "city_id='" + Convert.ToString(reg) + "'");
			}
			novo = false;
		}

		private void BtnApaga_Click(object sender, EventArgs e)
		{
			if (novo)
				MessageBox.Show("Nenhum registro selecionado para exclusão!");
			else
			{
				BD.ApagaLinha("city", "city_id='" + Convert.ToString(reg) + "'");
			}
		}

		private void BtnPrimeiro_Click(object sender, EventArgs e)
		{
			List<string>[] temp = new List<string>[4];
			temp = BD.Select("city", DadosCidade.ToStringTabelaLista(true), "", "ORDER BY city_id");

			AtualizaDadosMostrados(temp);
		}

		private void BtnAnterior_Click(object sender, EventArgs e)
		{
			List<string>[] temp = new List<string>[4];
			if (reg != 0)
			{
				temp = BD.Select("city", DadosCidade.ToStringTabelaLista(true), "city_id=" + Convert.ToString(reg - 1), "ORDER BY city_id");
			}
			else
			{
				temp = BD.Select("city", DadosCidade.ToStringTabelaLista(true), "", "ORDER BY city_id");
			}
			AtualizaDadosMostrados(temp);
		}

		private void BtnUltimo_Click(object sender, EventArgs e)
		{
			List<string>[] temp = new List<string>[4];
			temp = BD.Select("city", DadosCidade.ToStringTabelaLista(true), "", "ORDER BY city_id DESC");
			AtualizaDadosMostrados(temp);
		}

		private void BtnProx_Click(object sender, EventArgs e)
		{
			List<string>[] temp = new List<string>[4];
			if (reg != 0)
			{
				temp = BD.Select("city", DadosCidade.ToStringTabelaLista(true), "city_id=" + Convert.ToString(reg + 1), "ORDER BY city_id");
			}
			else
			{
				temp = BD.Select("city", DadosCidade.ToStringTabelaLista(true), "", "ORDER BY city_id");
				//TODO: Refinar para o caso que os registros não sejam sequenciais
			}
			AtualizaDadosMostrados(temp);
		}

		private void AtualizaDadosMostrados(List<string>[] info)
		{
			DadosCidade.IDCidade = Convert.ToInt32(info[0].ElementAt(0));
			DadosCidade.Cidade = info[1].ElementAt(0);
			DadosCidade.IDEstado = Convert.ToInt32(info[2].ElementAt(0));
			DadosCidade.ultimaAtualizacao = Convert.ToDateTime(info[3].ElementAt(0));
			reg = DadosCidade.IDCidade;
			TxtId.Text = Convert.ToString(DadosCidade.IDCidade);
			TxtCidade.Text = DadosCidade.Cidade;
			IdEstado = DadosCidade.IDEstado;
			LblUltatualiza.Text = Convert.ToString(DadosCidade.ultimaAtualizacao);
		}
    }
}
