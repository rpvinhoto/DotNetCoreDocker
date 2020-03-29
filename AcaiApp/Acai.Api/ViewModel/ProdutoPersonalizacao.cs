using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class ProdutoPersonalizacao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ProdutoId é um campo obrigatório.")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "PersonalizacaoId é um campo obrigatório.")]
        public int PersonalizacaoId { get; set; }
    }
}