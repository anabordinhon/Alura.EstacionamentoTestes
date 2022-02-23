using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Tests
{
     public class PatioTests
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            Veiculo veiculo = new Veiculo();
            Patio estacionamento = new Patio();
            veiculo.Placa = "DRT-9269";
            veiculo.Modelo = "Ford KA";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Proprietario = "Ana Clara";
            veiculo.Cor = "Azul";
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            
            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2,faturamento);
        }

        [Theory]
        [InlineData ("Ana Clara", "GEO-9090","Vermelho","Ford Focus")]
        [InlineData("Geovana", "DRY-6789", "Azul","Kombi")]
        [InlineData("Giuliano", "LEO-0090", "Rosa","Ferrari")]
        public void ValidaFaturamentoVariosVeiculos(string nome, string placa, string cor, string modelo)
        {
            //Arrange
            Veiculo veiculo = new Veiculo();
            Patio estacionamento = new Patio();
            veiculo.Placa = placa;
            veiculo.Modelo = modelo;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Proprietario = nome;
            veiculo.Cor = cor;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }
    }
}
