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
    }
}
