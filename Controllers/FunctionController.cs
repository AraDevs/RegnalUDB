using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class FunctionController : Controller<Funcione>
    {
        public Operation<Funcione> addRecord(Funcione o)
        {
            try
            {
                EntitySingleton.Context.Funciones.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Funcione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Funcione>.getFailOperation(e.Message);
            }
        }

        public Operation<Funcione> deleteRecord(Funcione o)
        {
            try
            {
                EntitySingleton.Context.Funciones.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Funcione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Funcione>.getFailOperation(e.Message);
            }
        }

        public Operation<Funcione> getRecords()
        {
            try
            {
                List<Funcione> data = EntitySingleton.Context.Funciones.ToList();
                return FactoryOperation<Funcione>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Funcione>.getFailOperation(e.Message);
            }
        }

        public Operation<Funcione> getActiveRecords()
        {
            try
            {
                List<Funcione> data = EntitySingleton.Context.Funciones.Where(x => x.baja).ToList();
                return FactoryOperation<Funcione>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Funcione>.getFailOperation(e.Message);
            }
        }

        public Operation<Funcione> updateRecord(Funcione o)
        {
            try
            {
                Funcione funcion = EntitySingleton.Context.Funciones.Find(o.idFuncion);
                EntitySingleton.Context.Entry(funcion).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Funcione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Funcione>.getFailOperation(e.Message);
            }
        }
    }
}
