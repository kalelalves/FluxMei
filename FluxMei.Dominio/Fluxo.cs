using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxMei.Dominio
{
    public class Fluxo
    {
        public int flx_seq { get; set; }
        public DateTime flx_data { get; set; }
        public int mei_seq { get; set; }
        public decimal flx_valor { get; set; }
        public decimal flx_saldo { get; set; }
        public string flx_observacao { get; set; }

    }
}
