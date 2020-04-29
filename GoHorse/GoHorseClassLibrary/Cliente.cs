using System.Collections.Generic;

namespace GoHorseClassLibrary
{
	public class Cliente : Pessoa
	{
		private int clienteId;

		private List<Cartao> cartoes;

		private List<Animal> animais;

		public int ClienteId
		{
			get => clienteId;
			set => clienteId = value;
		}

		public List<Cartao> Cartoes
		{
			get => cartoes;
			set => cartoes = value;
		}

		public List<Animal> Animais
		{
			get => animais;
			set => animais = value;
		}
		
	}

}