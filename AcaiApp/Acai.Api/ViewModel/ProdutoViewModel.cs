using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "TamanhoId é um campo obrigatório.")]
        public int TamanhoId { get; set; }

        [Required(ErrorMessage = "SaborId é um campo obrigatório.")]
        public int SaborId { get; set; }
    }
}