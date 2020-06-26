using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using GoHorseClassLibrary;
namespace GoHorseClassLibrary {
	public class Parada : Endereco {

		private int numero = 0;
		private Viagem viagem;

		public Parada(){

		}

		public int NumeroParada{
			get{
				return numero;
			}
			set{
				numero = value;
			}
		}

		public Viagem Viagem
		{
			get
			{
				return viagem;
			}
			set
			{
				viagem = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary