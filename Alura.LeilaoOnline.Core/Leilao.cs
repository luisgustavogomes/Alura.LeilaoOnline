using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {

        private Interessada _ultimoCliente;
        private IList<Lance> _lances;
        public double ValorDestino { get; set; }
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; set; }
        
        public Leilao(string peca, double valorDestino=0)
        {
            ValorDestino = valorDestino;
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
        }

        private bool NovoLanceEhAceito(Interessada cliente, double valor)
        {
            return (Estado == EstadoLeilao.LeilaoEmAndamento)
                && (cliente != _ultimoCliente);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceEhAceito(cliente, valor))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao() 
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
                throw new InvalidOperationException();
            if (ValorDestino > 0)
                GanhadorPelaModalidadeDeValorSuperiorMaisProxima();
            else
                GanhadorPelaModalidadeDeMelhorPreco();
            Estado = EstadoLeilao.LeilaoFinalizado;
        }

        private void GanhadorPelaModalidadeDeMelhorPreco()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(l => l.Valor)
                .LastOrDefault();
        }

        private void GanhadorPelaModalidadeDeValorSuperiorMaisProxima()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(l => l.Valor > ValorDestino)
                .OrderBy(l => l.Valor)
                .FirstOrDefault();
        }
    }
    public enum EstadoLeilao { LeilaoEmAndamento, LeilaoFinalizado, LeilaoAntesDoPregao }
}
