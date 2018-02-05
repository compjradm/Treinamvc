using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRCOM_TreinaDados.Model
{
    class Country
    {
        public Country() {
            Country_id = 0;
        }
        public int Country_id { get; set; }
        public string country { get; set; }
        public DateTime ultimoupdate { get; set; }

        public override string ToString()
        {
            string expressao = "country_id=" + Country_id + ",country='" + country + "',last_update='" + ultimoupdate + "'";
            return expressao;
        }
        public static List<string> ToStringTabelaLista(bool incluiID = false)
        {
            List<string> val = new List<string>();
            if (incluiID)
                val.Add("country_id");
            val.Add("country");
            val.Add("last_update");
            return val;
        }
        public List<string> ToStringValoresLista()
        {
            List<string> lista = new List<string>();
            lista.Add(country);
            lista.Add(ultimoupdate.ToString("yyyy-MM-dd"));
            return lista;
        }
    }
}
