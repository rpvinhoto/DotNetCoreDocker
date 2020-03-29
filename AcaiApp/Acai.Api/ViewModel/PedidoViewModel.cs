using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class PedidoViewModel
    { 
        [Required(ErrorMessage = "Tamanho é um campo obrigatório.")]
        public string TamanhoId { get; set; }

        [Required(ErrorMessage = "Sabor é um campo obrigatório.")]
        public string SaborId { get; set; }

        public IEnumerable<PedidoPersonalizacaoViewModel> Personalizacoes { get; set; }
    }
}