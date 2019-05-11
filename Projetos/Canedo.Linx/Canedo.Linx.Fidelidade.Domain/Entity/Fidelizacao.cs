using Canedo.Linx.Fidelidade.Domain.Abstract;
using System;

namespace Canedo.Linx.Fidelidade.Domain.Entity
{
    public class Fidelizacao : EntityBase
    {
        public Guid NsuCliente { get; set; }
        public string Resultado { get; set; }
        public long SaldoPontos { get; set; }
        public long SaldoEmPontos { get; set; }
        public decimal SaldoEmReais { get; set; }
    }
}
