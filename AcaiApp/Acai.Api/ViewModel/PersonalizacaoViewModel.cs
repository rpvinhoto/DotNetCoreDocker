using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class PersonalizacaoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Descricao é um campo obrigatório.")]
        [MaxLength(100, ErrorMessage = "Descrição deve ter no máximo 100 caracteres.")]
        public string Descricao { get; set; }

        [Range(0, 999, ErrorMessage = "Valor adicional deve estar entre 0 e 999999999.")]
        public decimal ValorAdicional { get; set; }

        [Range(0, 999, ErrorMessage = "Tempo de preparo adicional deve estar entre 0 e 999.")]
        public double TempoPreparoAdicional { get; set; }
    }
}