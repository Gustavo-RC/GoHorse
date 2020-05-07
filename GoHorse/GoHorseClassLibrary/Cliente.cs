using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using GoHorseClassLibrary;
namespace GoHorseClassLibrary {
	public class Cliente : Pessoa {

		private int id;
		private List<Cartao> cartoes;
		private List<Animal> animais;

		public Cliente(){

			animais = new List<Animal>();
			cartoes = new List<Cartao>();

		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public List<Cartao> Cartoes{
			get{
				return cartoes;
			}
			set{
				cartoes = value;
			}
		}

		public List<Animal> Animais{
			get{
				return animais;
			}
			set{
				animais = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary