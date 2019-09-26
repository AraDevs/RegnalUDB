using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;

namespace RegnalUDB.Controllers
{
    class SchoolarshipController:Controller<Escolaridad>
    {
        public List<Escolaridad> getRegisters()
        {
            return EntitySingleton.Context.Escolaridads.ToList();
        }

        public void saveRegister(Escolaridad o)
        {
            EntitySingleton.Context.Escolaridads.Add(o as Escolaridad);
            EntitySingleton.Context.SaveChanges();
        }
    }
}
