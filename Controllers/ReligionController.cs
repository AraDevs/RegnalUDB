using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class ReligionController : Controller<Religion>
    {
        public Operation<Religion> addRecord(Religion o)
        {
            throw new NotImplementedException();
        }

        public Operation<Religion> deleteRecord(Religion o)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
