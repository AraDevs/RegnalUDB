using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class MovementController : Controller<Movimiento>
    {
        public Operation<Movimiento> addRecord(Movimiento o)
        {
            try
            {
                EntitySingleton.Context.Movimientos.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Movimiento>.getSuccessOperation();
            }
            catch(Exception e)
            {
                return FactoryOperation<Movimiento>.getFailOperation(e.Message);
            }
        }

        public Operation<Movimiento> deleteRecord(Movimiento o)
        {
            throw new NotImplementedException();
        }

        public Operation<Movimiento> getRecords()
        {
            try
            {
                List<Movimiento> data = EntitySingleton.Context.Movimientos.ToList();
                return FactoryOperation<Movimiento>.getDataOperation(data);
            }
            catch(Exception e)
            {
                return FactoryOperation<Movimiento>.getFailOperation(e.Message);
            }
        }

        public Operation<Movimiento> updateRecord(Movimiento o)
        {
            try
            {
                Movimiento movimiento = EntitySingleton.Context.Movimientos.Find(o.idMovimiento);
                EntitySingleton.Context.Entry(movimiento).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Movimiento>.getSuccessOperation();
            }
            catch(Exception e)
            {
                return FactoryOperation<Movimiento>.getFailOperation(e.Message);
            }
        }
    }
}
