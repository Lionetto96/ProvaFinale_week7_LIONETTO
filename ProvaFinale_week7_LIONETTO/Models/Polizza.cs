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
        public DateOnly DataStipula { get; set; }
        public float ImportoAssicurazione { get; set; }
        public float RataMensile { get; set; }

        public string CodiceFiscale { get; set; }
        public Cliente Cliente { get; set; }

        public override string ToString()
        {
            return $"{NumeroPolizza} {DataStipula.ToShortDateString()} {ImportoAssicurazione} {RataMensile} cliente: {Cliente}";
        }
    }
}
