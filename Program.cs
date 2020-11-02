using System;
using System.Collections.Generic;

namespace Exercicio_03 {
	public enum Opcao {
		CadastrarCarro, CadastrarMoto, Editar, Excluir,
		ListarTodos, ListarPorPlaca, ListarPorMarcaEModelo,
		Finalizar
	};
	class Program {
		static void Main(string[] args) {
			var veiculo = new Veiculo();
			var veiculoPlaca = new Veiculo();
			var veiculos = new List<Veiculo>();
			string placaVeiculo = string.Empty;
			string marcaVeiculo = string.Empty;
			string modeloVeiculo = string.Empty;
			int tipoVeiculo = 0;
			int opcao = 0;

			MostrarMenuOpcao();
			do {
				Console.Write("Escolha uma opção: ");
				
				int.TryParse(Console.ReadLine(), out opcao);
				switch (opcao) {
					case (int)Opcao.CadastrarCarro:
						tipoVeiculo = 1;
						veiculo.CadastrarVeiculo(tipoVeiculo);
						LimpaTelaEMostraMenu();
						break;
					case (int)Opcao.CadastrarMoto:
						tipoVeiculo = 2;
						veiculo.CadastrarVeiculo(tipoVeiculo);
						LimpaTelaEMostraMenu();
						break;
					case (int)Opcao.Editar:
						veiculos = veiculo.ListarVeiculos();
						VisualizarListaVeiculosCadastrados(veiculos);
						BuscarVeiculoPorPlaca(veiculo, out veiculoPlaca, out placaVeiculo);
						if (veiculoPlaca != null) {
							VisualizarVeiculoPorPlaca(veiculoPlaca);
							veiculo.EditarVeiculo(veiculoPlaca);
							TrataAluguelDevolucaoVeiculo(veiculo, veiculoPlaca);
							VisualizarVeiculoPorPlaca(veiculoPlaca);
						} else {
							Console.WriteLine("Placa não existente!");
						}
						LimpaTelaEMostraMenu();
						break;
					case (int)Opcao.Excluir:
						BuscarVeiculoPorPlaca(veiculo, out veiculoPlaca, out placaVeiculo);
						if (veiculoPlaca != null) {
							veiculo.ExcluirVeiculo(placaVeiculo);
							veiculos = veiculo.ListarVeiculos();
							VisualizarListaVeiculosCadastrados(veiculos);
						}
						LimpaTelaEMostraMenu();
						break;
					case (int)Opcao.ListarTodos:
						veiculos = veiculo.ListarVeiculos();
						VisualizarListaVeiculosCadastrados(veiculos);
						LimpaTelaEMostraMenu();
						break;
					case (int)Opcao.ListarPorPlaca:
						BuscarVeiculoPorPlaca(veiculo, out veiculoPlaca, out placaVeiculo);
						if (veiculoPlaca == null) {
							Console.WriteLine("Veículo com esta placa não cadastrado! Para cadastrar novo escolha opção 0!");
						} else {
							VisualizarVeiculoPorPlaca(veiculoPlaca);
						}
						LimpaTelaEMostraMenu();
						break;
					case (int)Opcao.ListarPorMarcaEModelo:
						SolicitarMarcaEModelo(out string marcaDoVeiculo, out string modeloDoVeiculo);
						veiculos = veiculo.ListarVeiculosPorMarcaEModelo(marcaDoVeiculo, modeloDoVeiculo);
						VisualizarListaVeiculosCadastrados(veiculos);
						LimpaTelaEMostraMenu();
						break;
					case (int)Opcao.Finalizar:
						Console.WriteLine("Finalizando!!!");
						break;
					default:
						Console.WriteLine("Opção inválida!!");
						LimpaTelaEMostraMenu();
						break;
				}
			} while (opcao != (int)Opcao.Finalizar);
		}
		private static void LimpaTelaEMostraMenu() {
			Console.ReadLine();
			MostrarMenuOpcao();
		}
		private static void SolicitarMarcaEModelo(out string marcaDoVeiculo, out string modeloDoVeiculo) {
			Console.Write("Informe a marca do veículo: ");
			marcaDoVeiculo = Console.ReadLine();
			Console.Write("Informe o modelo do veículo: ");
			modeloDoVeiculo = Console.ReadLine();
		}
		private static void TrataAluguelDevolucaoVeiculo(Veiculo veiculo, Veiculo veiculoPlaca) {
			string editarVeiculo = "";
			if (veiculoPlaca.VeiculoAlugado) {
				do {
					Console.Write("Devolver veiculo? (S/N): ");
					editarVeiculo = Console.ReadLine().ToUpper();

				} while (editarVeiculo.ToUpper() != "S" && editarVeiculo.ToUpper() != "N");
				if (editarVeiculo == "S") {
					veiculoPlaca.DevolverVeiculoAlugado();
				}
			} else {
				do {
					Console.Write("Alugar veiculo? (S/N): ");
					editarVeiculo = Console.ReadLine().ToUpper();

				} while (editarVeiculo.ToUpper() != "S" && editarVeiculo.ToUpper() != "N");
				if (editarVeiculo == "S") {
					veiculoPlaca.AlugarVeiculo();
				}
			}
		}
		private static void BuscarVeiculoPorPlaca(Veiculo veiculo, out Veiculo veiculoPlaca, out string placaVeiculo) {
			Console.Write("Informe a placa do veículo: ");
			placaVeiculo = Console.ReadLine().ToUpper();
			veiculoPlaca = veiculo.ListarVeiculoPorPlaca(placaVeiculo);
		}
		private static void VisualizarVeiculoPorPlaca(Veiculo veiculoPlaca) {
			if (veiculoPlaca.TipoVeiculo == 1) {
				var carro = veiculoPlaca as Carro;
				carro.ListarVeiculo(carro);
			} else {
				var moto = veiculoPlaca as Moto;
				moto.ListarVeiculo(moto);
			}
		}
		private static void VisualizarListaVeiculosCadastrados(List<Veiculo> veiculos) {
			if (veiculos.Count > 0) {
				Console.WriteLine("Lista dos Veículos informados:");
				foreach (Veiculo veiculo in veiculos) {
					if (veiculo.TipoVeiculo == 1) {
						var carro = veiculo as Carro;
						carro.ListarVeiculo(carro);
					} else {
						var moto = veiculo as Moto;
						moto.ListarVeiculo(moto);
					}
				}
				Console.WriteLine($"Total Veiculos listados: {veiculos.Count}");
			} else {
				Console.WriteLine("Nenhum veículo cadastrado!");
			}
		}
		private static void MostrarMenuOpcao() {
			Console.Clear();
			Console.WriteLine("Opções:");
			Console.WriteLine("0 - Cadastrar Carro");
			Console.WriteLine("1 - Cadastrar Moto");
			Console.WriteLine("2 - Editar Veículo");
			Console.WriteLine("3 - Excluir Veículo");
			Console.WriteLine("4 - Listar Todos Veículos");
			Console.WriteLine("5 - Listar Veículo por Placa");
			Console.WriteLine("6 - Listar Veículo por Marca e Modelo");
			Console.WriteLine("7 - Finalizar");
		}
	}
}
