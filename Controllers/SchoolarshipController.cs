using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;

namespace RegnalUDB.Controllers
{
    class SchoolarshipController
    {
        ElSalvadorRegistroScoutsEntities context = new ElSalvadorRegistroScoutsEntities();
        public List<Escolaridad> obtenerEscolaridades()
        {
            
            return context.Escolaridads.ToList();
        }

        public void agregarEscolaridad(Escolaridad es)
        {
            context.Escolaridads.Add(es);
            context.SaveChanges();
        }
    }
}
