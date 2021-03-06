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
     public class PatioTests : IDisposable
    {   
        //Conceito de Setup
        //Arrange
        Veiculo veiculo = new Veiculo();
        Patio estacionamento = new Patio();

        [Fact]
        public void ValidaFaturamentoUmVeiculo()
        {
            //Arrange
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

        [Theory]
        [InlineData("Ana Clara", "GEO-9090", "Vermelho", "Ford Focus")]
        public void LocalizaVeiculoPorPlaca(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo.Placa = placa;
            veiculo.Modelo = modelo;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consulta = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consulta.Placa);

        }
        [Fact]
        public void AlterarDadosVeiculoPorPlaca()
        {
            //Arrange
            veiculo.Placa = "DRT-9269";
            veiculo.Modelo = "Ka";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Proprietario = "Ana Clara";
            veiculo.Cor = "Prata";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo() ;
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "DRT-9269";
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Opala";

            //Act
            var retorno = estacionamento.AlterarDadosVeiulo(veiculoAlterado);

            //Assert
            Assert.Equal(retorno.Cor, veiculoAlterado.Cor);

        }

        public void Dispose()
        {

        }
    }
}
