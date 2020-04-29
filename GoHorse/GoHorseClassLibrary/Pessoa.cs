using System.Collections.Generic;

namespace GoHorseClassLibrary
{
	public class Pessoa
	{
		private string nome;

		private string cpf;

		private List<Telefone> telefones;

		private string dataNascimento;

		private string email;

		private List<Endereco> enderecos;

		public string Nome
		{
			get => nome;
			set => nome = value;
		}

		public string Cpf
		{
			get => cpf;
			set => cpf = value;
		}

		public List<Telefone> Telefones
		{
			get => telefones;
			set => telefones = value;
		}

		public string DataNascimento
		{
			get => dataNascimento;
			set => dataNascimento = value;
		}

		public string Email
		{
			get => email;
			set => email = value;
		}

		public List<Endereco> Enderecos
		{
			get => enderecos;
			set => enderecos = value;
		}

	}

}