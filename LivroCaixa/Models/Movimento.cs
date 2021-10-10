using LivroCaixa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluxMei.Models
{
    public partial class Movimento
    {
        [Key]
        public decimal IdMovimento { get; set; }
        public string Descicao { get; set; }
        public decimal Total { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        [ForeignKey("fk_movimento_mei")]
        public string IdMei { get; set; }
        [ForeignKey("fk_movimento_tipomovimento")]
        public int TipoMovimentoId { get; set; }
        public virtual TipoMovimento TipomoMovimento { get; set; }
        public virtual Mei Mei { get; set; }
    }
}
