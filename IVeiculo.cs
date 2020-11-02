using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_03 {
	public interface IVeiculo {
		void CadastrarVeiculo(int tipoVeiculo);
		void EditarVeiculo(Veiculo veiculoEditar);
		void ExcluirVeiculo(string placaExcluir);
		List<Veiculo> ListarVeiculos();
		Veiculo ListarVeiculoPorPlaca(string placa);
		List<Veiculo> ListarVeiculosPorMarcaEModelo(string marca, string modelo);
	}
}
