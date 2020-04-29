using System;
using System.ComponentModel.DataAnnotations;

namespace GoHorseClassLibrary
{
	public class Animal
	{
		private int animalId;

		private string nRegistro;

		private string nome;

		private string raca;

		private string dataNascimento;

		private string descricao;

		private Cliente dono;

		public int AnimalId
		{
			get => animalId;
			set => animalId = value;
		}

		public string NRegistro
		{
			get => nRegistro;
			set => nRegistro = value;
		}

		public string Nome
		{
			get => nome;
			set => nome = value;
		}

		public string Raca
		{
			get => raca;
			set => raca = value;
		}

		public string DataNascimento
		{
			get => dataNascimento;
			set => dataNascimento = value;
		}

		public string Descricao
		{
			get => descricao;
			set => descricao = value;
		}

		public Cliente Dono
		{
			get => dono;
			set => dono = value;
		}


	}

}