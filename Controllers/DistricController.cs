using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RegnalUDB.Controllers
{
    class DistricController : Controller<Distrito>
    {
        public Operation<Distrito> addRecord(Distrito o)
        {
            throw new NotImplementedException();
        }

        public Operation<Distrito> deleteRecord(Distrito o)
        {
            throw new NotImplementedException();
        }

        public Operation<Distrito> getRecords()
        {
            try
            {
                List<Distrito> data = EntitySingleton.Context.Distritos.ToList();
                return FactoryOperation<Distrito>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Distrito>.getFailOperation(e.Message);
            }
        }

        public Operation<Distrito> getActiveRecords()
        {
            try
            {
                List<Distrito> data = EntitySingleton.Context.Distritos.Where(x => x.baja).ToList();
                return FactoryOperation<Distrito>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Distrito>.getFailOperation(e.Message);
            }
        }

        public Operation<Distrito> updateRecord(Distrito o)
        {
            throw new NotImplementedException();
        }
    }
}
