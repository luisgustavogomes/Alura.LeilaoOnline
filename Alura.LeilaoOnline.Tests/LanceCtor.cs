using Alura.LeilaoOnline.Core;
using Xunit;
using System;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100.00;

            //Assert
            Assert.Throws<ArgumentException>(
                //Act 
                () => new Lance(null, valorNegativo));
        }
    }
}
