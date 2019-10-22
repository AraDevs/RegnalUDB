using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class EventPositionController : Controller<EventoCargo>
    {
        public Operation<EventoCargo> addRecord(EventoCargo o)
        {
            try
            {
                EntitySingleton.Context.EventoCargoes.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<EventoCargo>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<EventoCargo>.getFailOperation(e.Message);
            }
        }

        public Operation<EventoCargo> deleteRecord(EventoCargo o)
        {
            try
            {
                EntitySingleton.Context.EventoCargoes.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<EventoCargo>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<EventoCargo>.getFailOperation(e.Message);
            }
        }

        public Operation<EventoCargo> getRecords()
        {
            throw new NotImplementedException();
        }

        public Operation<EventoCargo> updateRecord(EventoCargo o)
        {
            throw new NotImplementedException();
        }
    }
}
