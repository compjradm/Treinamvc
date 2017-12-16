using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace JRCOM_TreinaDados.Model
{
    class ConBanco
    {
        private string servidor;
        private string bancoDados;
        private string usuario;
        private string senha;
        private MySqlConnection conexao;

        public ConBanco(string bd, string usr, string pss, string servidor = "localhost"){
          PreparaConexao(bd, usr, pss, servidor);
        }
        private void PreparaConexao(string bd, string usr, string pss, string servidor = "localhost") {
          string connectionString = "SERVER=" + servidor + ";" + "DATABASE=" + bd + ";" + "UID=" + usr + ";" + "PASSWORD=" + pss + ";";
          conexao = new MySqlConnection(connectionString);
        }
        private bool AbreConexao(){
            try{
                conexao.Open();
                return true;
            }
            catch (MySqlException ex){
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
        private bool FechaConexao()){
            try{
                conexao.Close();
                return true;
            }
            catch (MySqlException ex){
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void InsereLinha(string tabela) {
            string query = "INSERT INTO " + tabela + " (name, age) VALUES('John Smith', '33')";
            if (this.OpenConnection() == true){
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void UpdateLine(string tabela){
            string query = "UPDATE "+ tabela + " SET name='Joe', age='22' WHERE name='John Smith'";
            if (this.AbreConexao() == true){
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conexao;
                cmd.ExecuteNonQuery();
                this.FechaConexao();
            }
        }
        public void ApagaLinha(string tabela){
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";
            if (this.AbreConexao() == true){
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.FechaConexao();
            }
        }
        public List< string >[] Select(string tabela){
            string query = "SELECT * FROM " + tabela;
            List< string >[] list = new List< string >[3];
            list[0] = new List< string >();
            list[1] = new List< string >();
            list[2] = new List< string >();
            if (this.OpenConnection() == true){
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read()){
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }else{
                return list;
            }
        }
    }
}
