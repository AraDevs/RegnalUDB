using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class InscriptionController : Controller<Inscripcione>
    {
        public Operation<Inscripcione> addRecord(Inscripcione o)
        {
            try
            {
                EntitySingleton.Context.Inscripciones.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Inscripcione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Inscripcione>.getFailOperation(e.Message);
            }
        }

        public Operation<Inscripcione> deleteRecord(Inscripcione o)
        {
            throw new NotImplementedException();
        }

        public Operation<Inscripcione> getRecords()
        {
            throw new NotImplementedException();
        }

        public Operation<Inscripcione> updateRecord(Inscripcione o)
        {
            try
            {
                Inscripcione i = EntitySingleton.Context.Inscripciones.Find(o.idInscripcion);
                EntitySingleton.Context.Entry(i).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Inscripcione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Inscripcione>.getFailOperation(e.Message);
            }
        }
    }
}
