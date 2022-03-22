using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTests
    {
        //Arrange
         Veiculo veiculo = new Veiculo();

        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            //Act
            veiculo.Frear(15);
            //Assert
            Assert.Equal(-225, veiculo.VelocidadeAtual);
        }
        [Fact]
        public void TestaTipoVeiculo()
        {
            
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void DadosAutomovel()
        {
            //Arrange
            var carro = new Veiculo();
            carro.Proprietario = "Carlos Silva";
            carro.Placa = "ZAP-7419";
            carro.Cor = "Verde";
            carro.Modelo = "Variante";
            carro.Tipo = TipoVeiculo.Automovel;
            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do veículo:", dados);
        }
    }
}
