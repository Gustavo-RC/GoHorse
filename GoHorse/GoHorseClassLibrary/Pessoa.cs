using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using GoHorseClassLibrary;
namespace GoHorseClassLibrary {
	public class Pessoa {

		private int id;
		private string nome = "";
		private string cpf = "";
		private List<Telefone> telefones;
		private string dataNascimento = "";
		private string email = "";
		private Endereco endereco;

		public Pessoa(){

			telefones = new List<Telefone>();
		}

		public int PessoaId{
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

		public string Cpf{
			get{
				return cpf;
			}
			set{
				cpf = value;
			}
		}

		public List<Telefone> Telefones{
			get{
				return telefones;
			}
			set{
				telefones = value;
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

		public string Email{
			get{
				return email;
			}
			set{
				email = value;
			}
		}

		public Endereco Endereco{
			get{
				return endereco;
			}
			set{
				endereco = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary