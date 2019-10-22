using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class EventSectionController : Controller<EventoSeccion>
    {
        public Operation<EventoSeccion> addRecord(EventoSeccion o)
        {
            try
            {
                EntitySingleton.Context.EventoSeccions.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<EventoSeccion>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<EventoSeccion>.getFailOperation(e.Message);
            }
        }

        public Operation<EventoSeccion> deleteRecord(EventoSeccion o)
        {
            try
            {
                EntitySingleton.Context.EventoSeccions.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<EventoSeccion>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<EventoSeccion>.getFailOperation(e.Message);
            }
        }

        public Operation<EventoSeccion> getRecords()
        {
            throw new NotImplementedException();
        }

        public Operation<EventoSeccion> updateRecord(EventoSeccion o)
        {
            throw new NotImplementedException();
        }
    }
}
