using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class EventController : Controller<Evento>
    {
        public Operation<Evento> addRecord(Evento o)
        {
            try
            {
                EntitySingleton.Context.Eventos.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Evento>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Evento>.getFailOperation(e.Message);
            }
        }

        public Operation<Evento> deleteRecord(Evento o)
        {
            try
            {
                EntitySingleton.Context.Eventos.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Evento>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Evento>.getFailOperation(e.Message);
            }
        }

        public Operation<Evento> getRecords()
        {
            try
            {
                List<Evento> data = EntitySingleton.Context.Eventos.ToList();
                return FactoryOperation<Evento>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Evento>.getFailOperation(e.Message);
            }
        }

        public Operation<Evento> getActiveRecords()
        {
            try
            {
                List<Evento> data = EntitySingleton.Context.Eventos.Where(x => x.baja).ToList();
                return FactoryOperation<Evento>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Evento>.getFailOperation(e.Message);
            }
        }

        public Operation<Evento> updateRecord(Evento o)
        {
            try
            {
                Evento position = EntitySingleton.Context.Eventos.Find(o.idEvento);
                EntitySingleton.Context.Entry(position).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Evento>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Evento>.getFailOperation(e.Message);
            }
        }
    }
}
