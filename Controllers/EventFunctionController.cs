using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class EventFunctionController : Controller<EventosFuncione>
    {
        public Operation<EventosFuncione> addRecord(EventosFuncione o)
        {
            try
            {
                EntitySingleton.Context.EventosFunciones.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<EventosFuncione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<EventosFuncione>.getFailOperation(e.Message);
            }
        }

        public Operation<EventosFuncione> deleteRecord(EventosFuncione o)
        {
            try
            {
                EntitySingleton.Context.EventosFunciones.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<EventosFuncione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<EventosFuncione>.getFailOperation(e.Message);
            }
        }

        public Operation<EventosFuncione> getRecords()
        {
            throw new NotImplementedException();
        }

        public Operation<EventosFuncione> updateRecord(EventosFuncione o)
        {
            throw new NotImplementedException();
        }
    }
}
