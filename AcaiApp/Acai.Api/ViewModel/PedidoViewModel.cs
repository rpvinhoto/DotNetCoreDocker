using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class PedidoViewModel
    { 
        [Required(ErrorMessage = "TamanhoId é um campo obrigatório.")]
        public int TamanhoId { get; set; }

        [Required(ErrorMessage = "SaborId é um campo obrigatório.")]
        public int SaborId { get; set; }

        public IEnumerable<PedidoPersonalizacaoViewModel> Personalizacoes { get; set; }
    }
}