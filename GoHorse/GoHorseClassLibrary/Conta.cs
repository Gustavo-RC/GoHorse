using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace GoHorseClassLibrary {
	public class Conta {

		private int id;
		private Motorista motorista;
		private string agencia = "";
		private string nConta = "";
		private string banco = "";

		public Conta(){

		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public Motorista Motorista{
			get{
				return motorista;
			}
			set{
				motorista = value;
			}
		}

		public string Agencia{
			get{
				return agencia;
			}
			set{
				agencia = value;
			}
		}

		public string NConta{
			get{
				return nConta;
			}
			set{
				nConta = value;
			}
		}

		public string Banco{
			get{
				return banco;
			}
			set{
				banco = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary