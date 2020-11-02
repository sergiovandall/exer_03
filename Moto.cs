using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_03 {
	class Moto : Veiculo {
		public string Guidao { get; set; }
		public int Marchas { get; set; }
		public int Pedal { get; set; }

		public Moto(string guidao, int marchas, int pedal) {
			Guidao = guidao;
			Marchas = marchas;
			Pedal = pedal;
		}

		public Moto() { }

		public void ListarVeiculo(Moto moto) {
			Console.WriteLine($"Placa {moto.Placa} Marca: {moto.Marca} Modelo: {moto.Modelo} Motor: {moto.Motor} " +
			 	$"Quantidade de Rodas: {moto.Rodas} Guidão: {moto.Guidao} Alugado: {moto.VeiculoAlugado} " +
				$"Marchas: {moto.Marchas} Pedais: {moto.Pedal}");
		}
	}
}
