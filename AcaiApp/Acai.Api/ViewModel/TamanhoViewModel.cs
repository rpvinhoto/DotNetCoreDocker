using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class TamanhoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Descricao é um campo obrigatório.")]
        [MaxLength(100, ErrorMessage = "Descrição deve ter no máximo 100 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Valor é um campo obrigatório.")]
        [Range(0, 999999999, ErrorMessage = "Valor deve estar entre 0 e 999999999.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "TempoPreparo é um campo obrigatório.")]
        [Range(0, 999, ErrorMessage = "Tempo de preparo deve estar entre 0 e 999.")]
        public double TempoPreparo { get; set; }
    }
}