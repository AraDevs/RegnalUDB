using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class CivilStatusController : Controller<EstadoCivil>
    {
        public Operation<EstadoCivil> addRecord(EstadoCivil o)
        {
            throw new NotImplementedException();
        }

        public Operation<EstadoCivil> deleteRecord(EstadoCivil o)
        {
            throw new NotImplementedException();
        }

        public Operation<EstadoCivil> getRecords()
        {
            try
            {
                List<EstadoCivil> data = EntitySingleton.Context.EstadoCivils.ToList();
                return FactoryOperation<EstadoCivil>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<EstadoCivil>.getFailOperation(e.Message);
            }
        }

        public Operation<EstadoCivil> getActiveRecords()
        {
            try
            {
                List<EstadoCivil> data = EntitySingleton.Context.EstadoCivils.Where(x => x.baja).ToList();
                return FactoryOperation<EstadoCivil>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<EstadoCivil>.getFailOperation(e.Message);
            }
        }

        public Operation<EstadoCivil> updateRecord(EstadoCivil o)
        {
            throw new NotImplementedException();
        }
    }
}
