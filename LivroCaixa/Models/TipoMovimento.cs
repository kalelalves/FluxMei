using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LivroCaixa.Models
{
    public class TipoMovimento
    {
        [Key]
        public int tipoid { get; set; }
        [StringLength(50)]
        public string descricao { get; set; }
        [StringLength(1)]
        public string receitadespesa { get; set; } 
        
    }
}