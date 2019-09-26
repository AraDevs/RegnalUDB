using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;

namespace RegnalUDB
{
    public sealed class EntitySingleton
    {
        private readonly static ElSalvadorRegistroScoutsEntities context = new ElSalvadorRegistroScoutsEntities();
        private EntitySingleton()
        {

        }

        public static ElSalvadorRegistroScoutsEntities Context
        {
            get { return EntitySingleton.context; }
        }
    }
}
