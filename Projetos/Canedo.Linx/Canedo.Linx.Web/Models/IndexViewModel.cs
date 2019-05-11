using Canedo.Linx.Fidelidade.Domain.Entity;
using System.Collections.Generic;

namespace Canedo.Linx.Web.Models
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Fidelizacoes = new List<Fidelizacao>();
        }
        public string NumeroCartao { get; set; }
        public Integracao Integracao { get; set; }
        public IEnumerable<Fidelizacao> Fidelizacoes { get; set; }
    }
}
