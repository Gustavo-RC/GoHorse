using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace GoHorseClassLibrary {
	public class Endereco {

		private int id;
		private string tipo = "";
		private string rua = "";
		private string numero = "";
		private string bairro = "";
		private string cidade = "";
		private string estado = "";
		private string cep = "";

		public Endereco(){

		}

		public int EnderecoId{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public string Tipo{
			get{
				return tipo;
			}
			set{
				tipo = value;
			}
		}

		public string Rua{
			get{
				return rua;
			}
			set{
				rua = value;
			}
		}

		public string Numero{
			get{
				return numero;
			}
			set{
				numero = value;
			}
		}

		public string Bairro{
			get{
				return bairro;
			}
			set{
				bairro = value;
			}
		}

		public string Cidade{
			get{
				return cidade;
			}
			set{
				cidade = value;
			}
		}

		public string Estado{
			get{
				return estado;
			}
			set{
				estado = value;
			}
		}

		public string Cep{
			get{
				return cep;
			}
			set{
				cep = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary