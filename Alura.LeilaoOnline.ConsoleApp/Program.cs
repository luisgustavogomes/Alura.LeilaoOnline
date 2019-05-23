using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();

        }

        private static void LeilaoComVariosLances()
        {
            //Arranje 
            IModalidadeAvaliacao modalidade = new OfertaMaiorValor();
            var leilao = new Leilao("Van", modalidade);
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
            Verifica(valorEsperador, valorObtido);
        }



        private static void LeilaoComApenasUmLance()
        {
            //Arranje 
            IModalidadeAvaliacao modalidade = new OfertaMaiorValor();
            var leilao = new Leilao("Van", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperador = 700;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperador, valorObtido);
        }

        private static void Verifica(double valorEsperador, double valorObtido)
        {
            var cor = Console.ForegroundColor;
            if (valorEsperador == valorObtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Teste Ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste Falhou! Esperado: {valorEsperador} | Obtido: {valorObtido} ");
            }
            Console.ForegroundColor = cor;
        }

    }
}
