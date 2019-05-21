using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {

        [Theory]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(1000, new double[] { 800, 900, 990, 1000 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperador, double[] ofertas)
        {
            //Arranje 
            var leilao = new Leilao("Van");
            var fulano = new Interessada("Fulano", leilao);


            foreach (var item in ofertas)
            {
                leilao.RecebeLance(fulano, item);
            }

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperador, valorObtido);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje
            var leilao = new Leilao("Van");

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperador = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperador, valorObtido);
        }



    }
}
