using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class PedidoPersonalizacaoViewModel
    {
        [Required(ErrorMessage = "PersonalizacaoId é um campo obrigatório.")]
        public int PersonalizacaoId { get; set; }
    }
}