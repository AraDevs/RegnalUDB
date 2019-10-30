using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class MedicalRecordController : Controller<FichasMedica>
    {
        public Operation<FichasMedica> addRecord(FichasMedica o)
        {
            try
            {
                EntitySingleton.Context.FichasMedicas.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<FichasMedica>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<FichasMedica>.getFailOperation(e.Message);
            }
        }

        public Operation<FichasMedica> deleteRecord(FichasMedica o)
        {
            throw new NotImplementedException();
        }

        public Operation<FichasMedica> getRecords()
        {
            throw new NotImplementedException();
        }

        public Operation<FichasMedica> updateRecord(FichasMedica o)
        {
            try
            {
                FichasMedica fm = EntitySingleton.Context.FichasMedicas.Find(o.idFichas);
                EntitySingleton.Context.Entry(fm).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<FichasMedica>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<FichasMedica>.getFailOperation(e.Message);
            }
        }
    }
}
