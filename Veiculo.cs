using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Exercicio_03 {
	public class Veiculo : IVeiculo {
		public int TipoVeiculo { get; private set; }
		public int Rodas { get; private set; }
		public string Motor { get; private set; }
		public string Placa { get; private set; }
		public string Marca { get; private set; }
		public string Modelo { get; private set; }
		public bool VeiculoAlugado { get; set; }

		private List<Veiculo> Veiculos = new List<Veiculo>();

		public Veiculo(int tipoVeiculo, string marca, string modelo, string placa, string motor, int rodas) {
			TipoVeiculo = tipoVeiculo;
			Marca = marca;
			Modelo = modelo;
			Placa = placa;
			Motor = motor;
			Rodas = rodas;
		}
		public Veiculo() {

		}
		public void AlugarVeiculo() {
			if (VeiculoAlugado)
				Console.WriteLine("Veículo já esta alugado!");
			else
				VeiculoAlugado = true;
		}
		public void DevolverVeiculoAlugado() {
			if (!VeiculoAlugado)
				Console.WriteLine("Veiculo não esta alugado!");
			else
				VeiculoAlugado = false;
		}
		public void CadastrarVeiculo(int tipoVeiculo) {
			if (tipoVeiculo == 1) {
				Console.WriteLine("Cadastre novo Carro:");
			} else {
				Console.WriteLine("Cadastre nova Moto:");
			}
			string placa = "";
			int contPlaca = 0;
			do {
				Console.Write("Placa: ");
				placa = Console.ReadLine().ToUpper();
				if (placa != "") {
					if (!validaPlaca(placa)) {
						Console.WriteLine("Placa fora do padrão!");
					} else {
						if (Veiculos.Count == 0) {
							contPlaca++;
						} else {
							foreach (var veiculo in Veiculos) {
								if (veiculo.Placa == placa) {
									Console.WriteLine("Placa já cadastrada para outro veículo!");
								} else {
									contPlaca++;
								}
							}
						}
					}
				}
			} while (contPlaca == 0);

			Console.Write("Marca: ");
			string marca = Console.ReadLine();
			Console.Write("Modelo: ");
			string modelo = Console.ReadLine();
			Console.Write("Potência do Motor: ");
			string motor = Console.ReadLine();
			Console.Write("Quantidade de Rodas: ");
			int rodas = int.Parse(Console.ReadLine());
			if (tipoVeiculo == 1) {
				Console.Write("Quantidade de Portas: ");
				int porta = int.Parse(Console.ReadLine());

				Console.Write("Quantidade de Portamalas: ");
				int portaMalas = int.Parse(Console.ReadLine());

				Console.Write("Quantidade de Parabrisas: ");
				int parabrisas = int.Parse(Console.ReadLine());

				var veiculoNovo = new Carro();
				veiculoNovo.TipoVeiculo = tipoVeiculo;
				veiculoNovo.Placa = placa;
				veiculoNovo.Marca = marca;
				veiculoNovo.Modelo = modelo;
				veiculoNovo.Motor = motor;
				veiculoNovo.Rodas = rodas;
				veiculoNovo.Porta = porta;
				veiculoNovo.PortaMalas = portaMalas;
				veiculoNovo.ParaBrisa = parabrisas;
				Veiculos.Add(veiculoNovo);
			} else {
				Console.Write("Tipo de Guidão: ");
				string guidao = Console.ReadLine();

				Console.Write("Quantidade de Marchas: ");
				int marchas = int.Parse(Console.ReadLine());

				Console.Write("Quantidade de Pedais: ");
				int pedal = int.Parse(Console.ReadLine());

				var veiculoNovo = new Moto();
				veiculoNovo.TipoVeiculo = tipoVeiculo;
				veiculoNovo.Placa = placa;
				veiculoNovo.Marca = marca;
				veiculoNovo.Modelo = modelo;
				veiculoNovo.Motor = motor;
				veiculoNovo.Rodas = rodas;
				veiculoNovo.Guidao = guidao;
				veiculoNovo.Marchas = marchas;
				veiculoNovo.Pedal = pedal;
				Veiculos.Add(veiculoNovo);
			}
			Console.WriteLine("Cadastro efetuado com sucesso!");
		}
		public void EditarVeiculo(Veiculo veiculoEditar) {
			Console.WriteLine($"Placa: {veiculoEditar.Placa}");
			string placa = veiculoEditar.Placa;

			var veiculoAchado = Veiculos.Where(x => x.Placa.Equals(placa)).FirstOrDefault();

			int contPlaca = 0;
			string placaNova = "";
			do {
				bool novaPlacaOK = true;
				Console.Write("Nova Placa: ");
				placaNova = Console.ReadLine().ToUpper();
				if (placaNova.Length != 0 && placaNova != veiculoEditar.Placa) {
					if (!validaPlaca(placaNova)) {
						Console.WriteLine("Nova Placa fora do padrão!");
					} else {
						foreach (var veiculo in Veiculos) {
							if (veiculo.Placa != placa && veiculo.Placa == placaNova) {
								Console.WriteLine("Placa já cadastrada para outro veículo!");
								novaPlacaOK = false;
							}
						}
						if (novaPlacaOK) {
							veiculoEditar.Placa = placaNova;
							contPlaca++;
						}
					}
				} else {
					contPlaca++;
				}
			} while (contPlaca == 0);

			bool campoIntInformado;
			
			Console.WriteLine($"Marca Atual: {veiculoEditar.Marca}");
			Console.Write("Nova Marca: ");
			string marca = Console.ReadLine();
			if (marca.Length != 0 && marca != veiculoEditar.Marca) {
				veiculoEditar.Marca = marca;
			}

			Console.WriteLine($"Modelo Atual: {veiculoEditar.Modelo}");
			Console.Write("Novo Modelo: ");
			string modelo = Console.ReadLine();
			if (modelo.Length != 0 && modelo != veiculoEditar.Modelo) {
				veiculoEditar.Modelo = modelo;
			}

			Console.WriteLine($"Potência do Motor Atual: {veiculoEditar.Motor}");
			Console.Write("Nova Potência do Motor: ");
			string motor = Console.ReadLine();
			if (motor.Length != 0 && motor != veiculoEditar.Motor) {
				veiculoEditar.Motor = motor;
			}
			Console.WriteLine($"Quantidade de Rodas Atual: {veiculoEditar.Rodas}");
			Console.Write("Quantidade de Rodas: ");
			campoIntInformado = int.TryParse(Console.ReadLine(), out int rodas);
			if (campoIntInformado) {
				if (rodas != veiculoEditar.Rodas) {
					veiculoEditar.Rodas = rodas;
				}
			}
			if (veiculoEditar.TipoVeiculo == 1) {
				var carro = veiculoEditar as Carro;

				Console.WriteLine($"Quantidade de Portas Atual: {carro.Porta}");
				Console.Write("Quantidade de Portas: ");
				campoIntInformado = int.TryParse(Console.ReadLine(), out int portas);
				if (campoIntInformado) {
					if (portas != carro.Porta) {
						carro.Porta = portas;
					}
				}

				Console.WriteLine($"Quantidade de Porta Malas Atual: {carro.PortaMalas}");
				Console.Write("Quantidade de Porta Malas: ");
				campoIntInformado = int.TryParse(Console.ReadLine(), out int portaMalas);
				if (campoIntInformado) {
					if (portaMalas != carro.PortaMalas) {
						carro.PortaMalas = portaMalas;
					}
				}

				Console.WriteLine($"Quantidade de Parabrisas Atual: {carro.ParaBrisa}");
				Console.Write("Quantidade de Parabrisas: ");
				campoIntInformado = int.TryParse(Console.ReadLine(), out int parabrisas);
				if (campoIntInformado) {
					if (parabrisas != carro.ParaBrisa) {
						carro.ParaBrisa = parabrisas;
					}
				}
			} else {
				var moto = veiculoEditar as Moto;

				Console.WriteLine($"Guidão Atual: {moto.Guidao}");
				Console.Write("Novo Guidão: ");
				string guidao = Console.ReadLine();
				if (guidao.Length != 0 && guidao != moto.Guidao) {
					moto.Guidao = guidao;
				}

				Console.WriteLine($"Quantidade de Marchas: {moto.Marchas}");
				Console.Write("Quantidade de Marchas: ");
				campoIntInformado = int.TryParse(Console.ReadLine(), out int marchas);
				if (campoIntInformado) {
					if (marchas != moto.Marchas) {
						moto.Marchas = marchas;
					}
				}

				Console.WriteLine($"Quantidade de Pedais: {moto.Pedal}");
				Console.Write("Quantidade de Pedais: ");
				campoIntInformado = int.TryParse(Console.ReadLine(), out int pedais);
				if (campoIntInformado) {
					if (pedais != moto.Pedal) {
						moto.Pedal = pedais;
					}
				}
			}
		}
		public void ExcluirVeiculo(string placaExcluir) {
			Console.WriteLine($"Placa do veículo a ser excluído: {placaExcluir}");

			foreach (var veiculo in Veiculos) {
				if (veiculo.Placa == placaExcluir) {
					if (veiculo.VeiculoAlugado) {
						Console.WriteLine("Este veículo esta alugado e não pode ser excluído!");
						break;
					} else {
						Veiculos.Remove(veiculo);
						Console.WriteLine("Veiculo excluido com sucesso!");
						break;
					}
				}
			}
		}
		public List<Veiculo> ListarVeiculos() {
			return Veiculos;
		}
		public Veiculo ListarVeiculoPorPlaca(string placa) {
			Veiculo veiculoPlaca = new Veiculo();
			veiculoPlaca = null;
			foreach (var veiculo in Veiculos) {
				if (veiculo.Placa == placa) {
					veiculoPlaca = veiculo;
					break;
				}
			}

			return veiculoPlaca;
		}
		public List<Veiculo> ListarVeiculosPorMarcaEModelo(string marca, string modelo) {
			List<Veiculo> veiculosMarcaEModelo = new List<Veiculo>();
			foreach (var veiculo in Veiculos) {
				if (veiculo.Marca == marca && veiculo.Modelo == modelo) {
					veiculosMarcaEModelo.Add(veiculo);
				}
			}
			return veiculosMarcaEModelo;
		}
		public bool validaPlaca(String placa) {
			Regex regexPadrao = new Regex(@"^[a-zA-Z]{3}\d{4}$");
			Regex regexMercosul = new Regex(@"^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");

			if (regexPadrao.IsMatch(placa)) {
				return true;
			} else {
				if (regexMercosul.IsMatch(placa)) {
					return true;
				} else {
					return false;
				}
			}
		}
	}
}
