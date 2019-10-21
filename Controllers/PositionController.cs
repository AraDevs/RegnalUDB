using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class PositionController : Controller<Cargo>
    {
        public Operation<Cargo> addRecord(Cargo o)
        {
            try
            {
                EntitySingleton.Context.Cargos.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Cargo>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Cargo>.getFailOperation(e.Message);
            }
        }

        public Operation<Cargo> deleteRecord(Cargo o)
        {
            try
            {
                EntitySingleton.Context.Cargos.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Cargo>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Cargo>.getFailOperation(e.Message);
            }
        }

        public Operation<Cargo> getRecords()
        {
            try
            {
                List<Cargo> data = EntitySingleton.Context.Cargos.ToList();
                return FactoryOperation<Cargo>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Cargo>.getFailOperation(e.Message);
            }
        }

        public Operation<Cargo> getActiveRecords()
        {
            try
            {
                List<Cargo> data = EntitySingleton.Context.Cargos.Where(x => x.baja == 1).ToList();
                return FactoryOperation<Cargo>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Cargo>.getFailOperation(e.Message);
            }
        }

        public Operation<Cargo> updateRecord(Cargo o)
        {
            try
            {
                Cargo position = EntitySingleton.Context.Cargos.Find(o.idCargo);
                EntitySingleton.Context.Entry(position).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Cargo>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Cargo>.getFailOperation(e.Message);
            }
        }
    }
}
