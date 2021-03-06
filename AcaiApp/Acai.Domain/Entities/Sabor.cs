﻿using System.Collections.Generic;

namespace Acai.Domain.Entities
{
    public class Sabor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double TempoPreparoAdicional { get; set; }

        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}