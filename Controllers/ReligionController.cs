using System;
using System.Collections.Generic;
using System.Linq;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class ReligionController : Controller<Religion>
    {
        public Operation<Religion> addRecord(Religion o)
        {
            try
            {
                EntitySingleton.Context.Religions.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Religion>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Religion>.getFailOperation(e.Message);
            }
        }

        public Operation<Religion> deleteRecord(Religion o)
        {
            try
            {
                EntitySingleton.Context.Religions.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Religion>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Religion>.getFailOperation(e.Message);
            }
        }

        public Operation<Religion> getRecords()
        {
            try
            {
                List<Religion> data = EntitySingleton.Context.Religions.ToList();
                return FactoryOperation<Religion>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Religion>.getFailOperation(e.Message);
            }
        }

        public Operation<Religion> getActiveRecords()
        {
            try
            {
                List<Religion> data = EntitySingleton.Context.Religions.Where(x => x.baja).ToList();
                return FactoryOperation<Religion>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Religion>.getFailOperation(e.Message);
            }
        }

        public Operation<Religion> updateRecord(Religion o)
        {
            try
            {
                Religion religion = EntitySingleton.Context.Religions.Find(o.idReligion);
                EntitySingleton.Context.Entry(religion).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Religion>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Religion>.getFailOperation(e.Message);
            }
        }
    }
}
