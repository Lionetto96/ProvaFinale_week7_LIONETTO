using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO.Models
{
    public class Cliente
    {
        public  string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }

        public ICollection<Polizza> Polizze { get; set; }=new List<Polizza>();

        public override string ToString()
        {
            return $"{CodiceFiscale} {Nome} {Cognome} {Indirizzo}";
        }
    }
}
