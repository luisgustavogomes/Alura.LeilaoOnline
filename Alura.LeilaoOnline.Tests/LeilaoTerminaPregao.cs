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
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var item = ofertas[i];
                if ((i % 2) == 0)
                    leilao.RecebeLance(fulano, item);
                else
                    leilao.RecebeLance(maria, item);
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
            leilao.IniciaPregao();
            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperador = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperador, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoFoiIniciado()
        {
            //Arranje
            var leilao = new Leilao("Van");

            //Assert
            Assert.Throws<System.InvalidOperationException>(
                //Act    
                () => leilao.TerminaPregao());
            
        }


        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorDestino, double valorEsperador, double[] ofertas)
        {
            //Arranje 
            var leilao = new Leilao("Van", valorDestino);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var item = ofertas[i];
                if ((i % 2) == 0)
                    leilao.RecebeLance(fulano, item);
                else
                    leilao.RecebeLance(maria, item);
            }
            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperador, valorObtido);
        }
    }

}
