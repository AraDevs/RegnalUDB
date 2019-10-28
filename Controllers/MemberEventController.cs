using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class MemberEventController : Controller<MiembroEvento>
    {
        public Operation<MiembroEvento> addRecord(MiembroEvento o)
        {
            try
            {
                EntitySingleton.Context.MiembroEventoes.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<MiembroEvento>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroEvento>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroEvento> deleteRecord(MiembroEvento o)
        {
            try
            {
                EntitySingleton.Context.MiembroEventoes.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<MiembroEvento>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroEvento>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroEvento> getRecords()
        {
            try
            {
                List<MiembroEvento> data = EntitySingleton.Context.MiembroEventoes.ToList();
                return FactoryOperation<MiembroEvento>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroEvento>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroEvento> getRecordsByEvent(Evento ev)
        {
            try
            {
                List<MiembroEvento> data = EntitySingleton.Context.MiembroEventoes.Where(x => x.idEvento == ev.idEvento).ToList();
                return FactoryOperation<MiembroEvento>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroEvento>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroEvento> updateRecord(MiembroEvento o)
        {
            try
            {
                MiembroEvento me = EntitySingleton.Context.MiembroEventoes.Find(o.idMiembroEvento);
                EntitySingleton.Context.Entry(me).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<MiembroEvento>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroEvento>.getFailOperation(e.Message);
            }
        }
    }
}
