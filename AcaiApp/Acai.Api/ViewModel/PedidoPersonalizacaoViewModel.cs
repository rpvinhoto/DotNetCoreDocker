using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class PedidoPersonalizacaoViewModel
    {
        [Required(ErrorMessage = "Personalizacao é um campo obrigatório.")]
        public string PersonalizacaoId { get; set; }
    }
}