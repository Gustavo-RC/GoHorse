using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using GoHorseClassLibrary;
namespace GoHorseClassLibrary {
	public class Viagem {

		private int id;
		private Veiculo veiculo;
		private Animal animal;
		private List<Parada> paradas;
		private string dataOrigem = "";
		private string dataDestino = "";
		private double valorViagem = 0.0;
		private Endereco enderecoOrigem;
		private Endereco enderecoDestino;

		public Viagem(){
			paradas = new List<Parada>();
		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public Veiculo Veiculo{
			get{
				return veiculo;
			}
			set{
				veiculo = value;
			}
		}

		public Animal Animal{
			get{
				return animal;
			}
			set{
				animal = value;
			}
		}

		public List<Parada> Paradas{
			get{
				return paradas;
			}
			set{
				paradas = value;
			}
		}

		public string DataOrigem{
			get{
				return dataOrigem;
			}
			set{
				dataOrigem = value;
			}
		}

		public string DataDestino{
			get{
				return dataDestino;
			}
			set{
				dataDestino = value;
			}
		}

		public double ValorViagem{
			get{
				return valorViagem;
			}
			set{
				valorViagem = value;
			}
		}

		public Endereco EnderecoOrigem{
			get{
				return enderecoOrigem;
			}
			set{
				enderecoOrigem = value;
			}
		}

		public Endereco EnderecoDestino{
			get{
				return enderecoDestino;
			}
			set{
				enderecoDestino = value;
			}
		}

	}

}//end namespace GoHorseClassLibrary