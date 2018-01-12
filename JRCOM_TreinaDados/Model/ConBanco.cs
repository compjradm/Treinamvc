using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;

namespace JRCOM_TreinaDados.Model
{
    class ConBanco
    {
        private string servidor;
        private string bancoDados;
        private string usuario;
        private string senha;
        private string porta;
        private NpgsqlConnection conexao;

        public ConBanco(string bd, string usr, string pss, string svr = "localhost", string port = "5432")
        {
          PreparaConexao(bd, usr, pss, svr);
            servidor = svr;
            bancoDados = bd;
            usuario = usr;
            senha = pss;
            porta = port;
        }
        private void PreparaConexao(string bd, string usr, string pss, string svr = "localhost", string port = "5432") {
          string connectionString = "SERVER=" + svr + ";Port=" + port + ";User ID=" + usr + ";PASSWORD=" + pss + ";DATABASE=" + bd + ";";
          conexao = new NpgsqlConnection(connectionString);
        }
        private bool AbreConexao(){
            try{
                conexao.Open();
                return true;
            }
            catch (NpgsqlException ex){
                switch (ex.ErrorCode)
                {
                    case 0:
                        MessageBox.Show("Falha ao conectar no servidor de dados.");
                        break;
                    case 1045:
                        MessageBox.Show("A combinacao de usuario e senha nao existe. Tente novamente.");
                        break;
                }
                return false;
            }
        }
        private bool FechaConexao(){
            try{
                conexao.Close();
                return true;
            }
            catch (NpgsqlException ex){
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
                NpgsqlCommand cmd = new NpgsqlCommand(query, conexao);
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
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conexao;
                cmd.ExecuteNonQuery();
                this.FechaConexao();
            }
        }
        public void ApagaLinha(string tabela, string filtro){
            string query = "DELETE FROM " + tabela + " WHERE " + filtro;
            if (this.AbreConexao() == true){
                NpgsqlCommand cmd = new NpgsqlCommand(query, conexao);
                cmd.ExecuteNonQuery();
                this.FechaConexao();
            }
        }
        public List< string >[] Select(string tabela, List<string> campos, string filtro = ""){
            string query = "SELECT * FROM " + tabela;
            int qtReg = campos.Count;
            if (filtro != "")
                query += "WHERE " + filtro;
            List< string >[] list = new List< string >[qtReg];
            for (int i = 0; i < qtReg; i++)
            {
                list[i] = new List<string>();
            }
            if (this.AbreConexao() == true){
                NpgsqlCommand cmd = new NpgsqlCommand(query, conexao);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
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
