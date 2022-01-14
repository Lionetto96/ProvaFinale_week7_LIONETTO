using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO.Models
{
    public class Vita :Polizza
    {
        public int AnniAssicurato { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"  età:{AnniAssicurato}";
        }
    }
}
