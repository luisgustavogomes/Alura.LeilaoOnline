using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {

        [Fact]
        public void LeilaoComVariosLances()
        {
            //Arranje 
            var leilao = new Leilao("Van");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperador = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperador, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLance()
        {
            //Arranje 
            var leilao = new Leilao("Van");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperador = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperador, valorObtido);
        }

        [Fact]
        public void LeilaoComVariosLancesOrdenadosPorValor()
        {
            //Arranje 
            var leilao = new Leilao("Van");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(fulano, 1000);

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperador = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperador, valorObtido);
        }

        [Fact]
        public void LeilaoComTresClientes()
        {
            //Arranje 
            var leilao = new Leilao("Van");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            var beltrano = new Interessada("beltrano", leilao);
            leilao.RecebeLance(fulano, 100);
            leilao.RecebeLance(maria, 200);
            leilao.RecebeLance(fulano, 350);
            leilao.RecebeLance(maria, 560);
            leilao.RecebeLance(beltrano, 900);

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperador = 900;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(beltrano, leilao.Ganhador.Cliente);
            Assert.Equal(valorEsperador, valorObtido);

        }
    }
}
