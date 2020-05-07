using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace GoHorseClassLibrary {
	public class Veiculo {

		private int id;
		private Motorista motorista;
		private string marca = "";
		private string modelo = "";
		private string anoFabricacao = "";
		private string placa = "";

		public Veiculo(){

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

		public string Marca{
			get{
				return marca;
			}
			set{
				marca = value;
			}
		}

		public string Modelo{
			get{
				return modelo;
			}
			set{
				modelo = value;
			}
		}

		public string AnoFabricacao{
			get{
				return anoFabricacao;
			}
			set{
				anoFabricacao = value;
			}
		}

		public string Placa{
			get{
				return placa;
			}
			set{
				placa = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary