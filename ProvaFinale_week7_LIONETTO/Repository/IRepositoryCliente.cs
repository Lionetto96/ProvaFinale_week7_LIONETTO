using ProvaFinale_week7_LIONETTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO.Repository
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        public Cliente? GetByCodiceFiscale(string codiceFiscale);
    }
}
