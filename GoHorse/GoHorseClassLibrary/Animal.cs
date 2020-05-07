using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace GoHorseClassLibrary {
	public class Animal {

		private int id;
		private string nRegistro = "";
		private string nome = "";
		private string raca = "";
		private string dataNascimento = "";
		private string descricao = "";
		private Cliente cliente;

		public Animal(){

		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public string NRegistro{
			get{
				return nRegistro;
			}
			set{
				nRegistro = value;
			}
		}

		public string Nome{
			get{
				return nome;
			}
			set{
				nome = value;
			}
		}

		public string Raca{
			get{
				return raca;
			}
			set{
				raca = value;
			}
		}

		public string DataNascimento{
			get{
				return dataNascimento;
			}
			set{
				dataNascimento = value;
			}
		}

		public string Descricao{
			get{
				return descricao;
			}
			set{
				descricao = value;
			}
		}

		public Cliente Cliente{
			get{
				return cliente;
			}
			set{
				cliente = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary