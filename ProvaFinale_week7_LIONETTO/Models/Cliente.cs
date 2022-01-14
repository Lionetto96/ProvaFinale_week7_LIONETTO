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

        public float SpesaTotRate()
        {
            float totale = 0;
            foreach (var cliente in Polizze )
            {
                totale +=cliente.RataMensile ;
               
            }
            return totale;
        }

        public override string ToString()
        {
            return $"CLIENTE:{CodiceFiscale} {Nome} {Cognome} {Indirizzo} SPESA TOT. MENSILE:{SpesaTotRate()}";
        }
    }
}
