using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO.Models
{
    public class RcAuto : Polizza
    {
        [MaxLength(5)]
        public string Targa { get; set; }
        public int Cilindrata { get; set; }

    }
}
