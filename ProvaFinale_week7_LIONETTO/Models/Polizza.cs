using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO.Models
{
    public  class Polizza
    {
        public int NumeroPolizza { get; set; }
        public DateTime DataStipula { get; set; }
        public float ImportoAssicurazione { get; set; }
        public float RataMensile { get; set; }

        public string CodiceFiscale { get; set; }
        public Cliente Cliente { get; set; }

        public override string ToString()
        {
            return $"NUMERO  POLIZZA:{NumeroPolizza} DATA STIPULA:{DataStipula.ToShortDateString()} IMPORTO TOTALE ASSICURAZIONE:{ImportoAssicurazione} IMPORTO RATA MENSILE:{RataMensile} cliente: {Cliente}";
        }
    }
}
