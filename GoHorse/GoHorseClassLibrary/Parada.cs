using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using GoHorseClassLibrary;
namespace GoHorseClassLibrary {
	public class Parada : Endereco {

		private int id;
		private int numero = 0;

		public Parada(){

		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public int NumeroParada{
			get{
				return numero;
			}
			set{
				numero = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary