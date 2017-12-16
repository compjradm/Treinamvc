using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace JRCOM_TreinaDados.Model{
	public class City{
		private int city_id;
		private string city;
		private int country_id;
		private DateTime last_update;

		public City(){
            IDCidade = 0;
            last_update = new DateTime();
		}
        public int IDCidade {
            get { return city_id; }
            set { city_id = value; }
            
		}
		public string Cidade{
			get {return city;}
			set {city = value;}
		}
		public int IDEstado{
			get {return country_id;}
			set {country_id = value;}
		}
		public datetime ultimaAtualizacao{
			get {return last_update;}
			set {last_update = value;}
		}
		public List<string> ToStringLista(){
			List<string> lista = new List<string>();
			lista.Add(Cidade);
			lista.Add(IDEstado.ToString());
            lista.Add(ultimaAtualizacao.ToString("yyyy-MM-dd"));
            return lista;
		}
	}
}
