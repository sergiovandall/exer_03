using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_03 {
	class Carro : Veiculo {
		public int Porta { get; set; }
		public int PortaMalas { get; set; }
		public int ParaBrisa { get; set; }

		public Carro(int porta, int portamalas, int parabrisa) {
			Porta = porta;
			PortaMalas = portamalas;
			ParaBrisa = parabrisa;
		}

		public Carro() { }
		public void ListarVeiculo(Carro carro) {
			Console.WriteLine($"Placa {carro.Placa} Marca: {carro.Marca} Modelo: {carro.Modelo} Motor: {carro.Motor} " +
			 	$"Quantidade de Rodas: {carro.Rodas} Portas: {carro.Porta} Alugado: {carro.VeiculoAlugado} " +
				$"Porta Malas: {carro.PortaMalas} Parabrisas: {carro.ParaBrisa}");
		}

	}


}
