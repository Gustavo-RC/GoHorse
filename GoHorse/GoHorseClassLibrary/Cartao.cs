using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace GoHorseClassLibrary {
	public class Cartao {

		private int id;
		private string nome = "";
		private string nCartao = "";
		private string validade = "";
		private int cv = 0;
		private Cliente cliente;

		public Cartao(){

		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
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

		public string NCartao{
			get{
				return nCartao;
			}
			set{
				nCartao = value;
			}
		}

		public string Validade{
			get{
				return validade;
			}
			set{
				validade = value;
			}
		}

		public int Cv{
			get{
				return cv;
			}
			set{
				cv = value;
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