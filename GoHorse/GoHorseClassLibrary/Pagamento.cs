using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using GoHorseClassLibrary;
namespace GoHorseClassLibrary {
	public class Pagamento {

		private int id;
		private Viagem viagem;
		private Cartao cartao;
		private Conta conta;

		public Pagamento(){

		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public Viagem Viagem{
			get{
				return viagem;
			}
			set{
				viagem = value;
			}
		}

		public Cartao Cartao{
			get{
				return cartao;
			}
			set{
				cartao = value;
			}
		}

		public Conta Conta{
			get{
				return conta;
			}
			set{
				conta = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary