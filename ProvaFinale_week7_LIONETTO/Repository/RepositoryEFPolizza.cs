using Microsoft.EntityFrameworkCore;
using ProvaFinale_week7_LIONETTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO.Repository
{
    public class RepositoryEFPolizza : IRepositoryPolizza
    {
        public bool Create(Polizza item)
        {
            bool result = false;
            using (var ctx = new Context())
            {
                ctx.Polizze.Add(item);
                ctx.SaveChanges();
                result = true;

            }
            return result;
        }

        public ICollection<Polizza> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Polizze.Include(p => p.Cliente).ToList();
            }
        }
    }
}
