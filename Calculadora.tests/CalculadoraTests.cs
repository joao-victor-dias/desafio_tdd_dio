using System;
using Xunit;

namespace Calculadora.tests
{
    public class CalculadoraTests
    {
        public Calculadora classe()
        {
            string data = new DateTime().ToString();
            Calculadora calc = new Calculadora(data);

            return calc;
        }        

        [Theory]
        [InlineData (2,3,5)]
        [InlineData (8,5,13)]
        public void somarDoisNumeros(int valor1, int valor2, int resultado)
        {
            Calculadora calc = classe();
            int resultaoSoma = calc.somar(valor1, valor2);
            Assert.Equal(resultado, resultaoSoma);
        }

        [Theory]
        [InlineData(2, 3, -1)]
        [InlineData(8, 5, 3)]
        public void subtrairDoisNumeros(int valor1, int valor2, int resultado)
        {
            Calculadora calc = classe();
            int resultaoSubtracao = calc.subtrair(valor1, valor2);
            Assert.Equal(resultado, resultaoSubtracao);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(8, 5, 40)]
        public void multiplicarDoisNumeros(int valor1, int valor2, int resultado)
        {
            Calculadora calc = classe();
            int resultaoMultiplicacao = calc.multiplicar(valor1, valor2);
            Assert.Equal(resultado, resultaoMultiplicacao);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(9, 3, 3)]
        public void dividirDoisNumeros(int valor1, int valor2, int resultado)
        {
            Calculadora calc = classe();
            int resultaoDivisao = calc.dividir(valor1, valor2);
            Assert.Equal(resultado, resultaoDivisao);
        }

        [Fact]
        public void dividirNumeroPor0()
        {
            Calculadora calc = classe();
            Assert.Throws<DivideByZeroException>(
                    () => calc.dividir(6,0)
            );
        }

        [Fact]
        public void testeHistorico()
        {
            Calculadora calc = classe();
            calc.somar(1, 2);
            calc.somar(3, 4);
            calc.somar(4, 5);
            calc.somar(5, 6);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }


    }


}
