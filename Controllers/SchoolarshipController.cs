using System;
using System.Collections.Generic;
using System.Linq;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class SchoolarshipController : Controller<Escolaridad>
    {

        public Operation<Escolaridad> addRecord(Escolaridad o)
        {
            try
            {
                EntitySingleton.Context.Escolaridads.Add(o as Escolaridad);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Escolaridad>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Escolaridad>.getFailOperation(e.Message);
            }
        }

        public Operation<Escolaridad> updateRecord(Escolaridad o)
        {
            throw new NotImplementedException();
        }

        public Operation<Escolaridad> deleteRecord(Escolaridad o)
        {
            throw new NotImplementedException();
        }

        public Operation<Escolaridad> getRecords()
        {
            try
            {
                List<Escolaridad> data = EntitySingleton.Context.Escolaridads.ToList();
                return FactoryOperation<Escolaridad>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Escolaridad>.getFailOperation(e.Message);
            }
        }
    }
}
