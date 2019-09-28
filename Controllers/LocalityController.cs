using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class LocalityController : Controller<Localidade>
    {
        public Operation<Localidade> addRecord(Localidade o)
        {
            throw new NotImplementedException();
        }

        public Operation<Localidade> deleteRecord(Localidade o)
        {
            throw new NotImplementedException();
        }

        public Operation<Localidade> getRecords()
        {
            try
            {
                List<Localidade> data = EntitySingleton.Context.Localidades.ToList();
                return FactoryOperation<Localidade>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Localidade>.getFailOperation(e.Message);
            }
        }

        public Operation<Localidade> updateRecord(Localidade o)
        {
            throw new NotImplementedException();
        }
    }
}
