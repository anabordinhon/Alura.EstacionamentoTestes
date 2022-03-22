using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTests : IDisposable
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

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaCadastralAutomovel()
        {
            //Arrange
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";
            veiculo.Tipo = TipoVeiculo.Automovel;
            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do veículo:", dados);
        }

        public void Dispose()
        {
            
        }
    }
}
