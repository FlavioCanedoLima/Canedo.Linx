using Canedo.Linx.Fidelidade.Domain.Abstract;

namespace Canedo.Linx.Fidelidade.Domain.Entity
{
    public class Integracao : EntityBase
    {
        public string ChaveIntegracao { get; set; }
        public string CodigoLoja { get; set; }
    }
}
