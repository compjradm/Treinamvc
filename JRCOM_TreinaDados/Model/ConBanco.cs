using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace JRCOM_TreinaDados.Model
{
    class ConBanco
    {
        private string servidor;
        private string bancoDados;
        private string usuario;
        private string senha;
        private MySqlConnection conexao;

        public ConBanco(string bd, string usr, string pss, string svr = "localhost"){
          PreparaConexao(bd, usr, pss, svr);
            servidor = svr;
            bancoDados = bd;
            usuario = usr;
            senha = pss;
        }
        private void PreparaConexao(string bd, string usr, string pss, string svr = "localhost") {
          string connectionString = "SERVER=" + svr + ";" + "DATABASE=" + bd + ";" + "UID=" + usr + ";" + "PASSWORD=" + pss + ";";
          conexao = new MySqlConnection(connectionString);
        }
        private bool AbreConexao(){
            try{
                conexao.Open();
                return true;
            }
            catch (MySqlException ex){
                {
                    switch (ex.ErrorCode)
                    {
                        case 0:
                            MessageBox.Show("Falha ao conectar no servidor de dados.");
                            break;
                        case 1045:
                            MessageBox.Show("A combinacao de usuario e senha nao existe. Tente novamente.");
                            break;
                    }
                }
                return false;
            }
        }
        private bool FechaConexao(){
            try{
                conexao.Close();
                return true;
            }
            catch (MySqlException ex){
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void InsereLinha(string tabela, List<string> campos, List<string> valores) {
			string query = "INSERT INTO " + tabela + " (";
			foreach (string item in campos)
			{
				query += item;
				query += ", ";
			}
			query = query.Remove(query.Length - 2);
			query += ") VALUES(";
			foreach (string item in valores)
			{
				query += item;
				query += ", ";
			}
			query = query.Remove(query.Length - 2);
			query += ")";
            if (this.AbreConexao() == true){
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.ExecuteNonQuery();
                this.FechaConexao();
            }
        }
        public void UpdateLine(string tabela, List<string> campos, List<string> valores, string filtro = ""){
			string query = "UPDATE " + tabela + " SET ";
			string temp1, temp2;
			while (campos.Count > 0)
			{
				temp1 = campos.First();
				temp2 = valores.First();
				query += temp1 + "=" + "'" + temp2 + "'";
				campos.RemoveAt(0);
				valores.RemoveAt(0);
				if (campos.Count > 0)
					query += ", ";
			}
			if (filtro != "")
				query += "WHERE " + filtro;
            if (this.AbreConexao() == true){
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conexao;
                cmd.ExecuteNonQuery();
                this.FechaConexao();
            }
        }
        public void ApagaLinha(string tabela, string filtro){
            string query = "DELETE FROM " + tabela + " WHERE " + filtro;
            if (this.AbreConexao() == true){
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.ExecuteNonQuery();
                this.FechaConexao();
            }
        }
        public List< string >[] Select(string tabela, List<string> campos, string filtro = "", string outrosParam = ""){
			string query = "SELECT * FROM " + tabela;
			int qtReg = campos.Count;
			if (filtro != "")
				query += " WHERE " + filtro;
			if (outrosParam != "")
				query += " " + outrosParam;
			List<string>[] list = new List<string>[qtReg];
			for (int i = 0; i < qtReg; i++)
			{
				list[i] = new List<string>();
			}
            if (this.AbreConexao() == true){
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                switch (tabela)
				{
					case "city":
						while (dataReader.Read())
						{
							list[0].Add(dataReader["city_id"] + "");
							list[1].Add(dataReader["city"] + "");
							list[2].Add(dataReader["country_id"] + "");
							list[3].Add(dataReader["last_update"] + "");
						}
						break;
				}
                dataReader.Close();
                this.FechaConexao();
                return list;
            }else{
                return list;
            }
        }
    }
}
