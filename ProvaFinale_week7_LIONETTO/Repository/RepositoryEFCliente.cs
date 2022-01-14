using ProvaFinale_week7_LIONETTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO.Repository
{
    public class RepositoryEFCliente : IRepositoryCliente
    {
        public bool Create(Cliente item)
        {
            bool result = false;
            using (var ctx = new Context())
            {
                ctx.Clienti.Add(item);
                ctx.SaveChanges();
                result = true;

            }
            return result;
        }

        public ICollection<Cliente> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Clienti.ToList();
            }
        }
    }
}
