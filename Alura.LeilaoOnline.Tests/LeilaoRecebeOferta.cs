﻿using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(4, new double[] { 800, 900, 1000, 990 })]
        [InlineData(5, new double[] { 800, 900, 1000, 990, 1290 })]
        [InlineData(6, new double[] { 800, 900, 1000, 990, 1300, -100 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperado, double[]ofertas )
        {
            //Arranje
            var leilao = new Leilao("Van");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var item in ofertas) 
            {
                leilao.RecebeLance(fulano, item);
            }

            leilao.TerminaPregao();

            //Act 
            foreach (var item in ofertas)
            {
                leilao.RecebeLance(fulano, item);
            }

            //Assert
            var qtdeLances = leilao.Lances.Count();

            Assert.Equal(qtdeEsperado, qtdeLances);
        }


    }
}