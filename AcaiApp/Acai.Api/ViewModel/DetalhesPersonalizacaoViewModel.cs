using Acai.Domain.Entities;

namespace Acai.Api.ViewModel
{
    public class DetalhesPersonalizacaoViewModel
    {
        public string Personalizacao { get; set; }
        public double TempoAdicional { get; set; }
        public decimal ValorAdicional { get; set; }

        public DetalhesPersonalizacaoViewModel(Personalizacao personalizacao)
        {
            Personalizacao = personalizacao.Descricao;
            TempoAdicional = personalizacao.TempoPreparoAdicional;
            ValorAdicional = personalizacao.ValorAdicional;
        }
    }
}