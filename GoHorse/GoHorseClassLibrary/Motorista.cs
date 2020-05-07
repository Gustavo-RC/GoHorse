using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using GoHorseClassLibrary;
namespace GoHorseClassLibrary {
	public class Motorista : Pessoa {

		private int id;
		private string nRegistroCnh = "";
		private string validadeCnh = "";
		private string categoriaCnh = "";
		private List<Conta> contas;
		private List<Veiculo> veiculos;

		public Motorista(){

			contas = new List<Conta>();
			veiculos = new List<Veiculo>();

		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public string NRegistroCnh{
			get{
				return nRegistroCnh;
			}
			set{
				nRegistroCnh = value;
			}
		}

		public string ValidadeCnh{
			get{
				return validadeCnh;
			}
			set{
				validadeCnh = value;
			}
		}

		public string CategoriaCnh{
			get{
				return categoriaCnh;
			}
			set{
				categoriaCnh = value;
			}
		}

		public List<Conta> Contas{
			get{
				return contas;
			}
			set{
				contas = value;
			}
		}

		public List<Veiculo> Veiculos{
			get{
				return veiculos;
			}
			set{
				veiculos = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary