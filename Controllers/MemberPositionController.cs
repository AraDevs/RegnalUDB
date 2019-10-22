using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class MemberPositionController : Controller<MiembroCargo>
    {
        public Operation<MiembroCargo> addRecord(MiembroCargo o)
        {
            try
            {
                EntitySingleton.Context.MiembroCargoes.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<MiembroCargo>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroCargo>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroCargo> deleteRecord(MiembroCargo o)
        {
            try
            {
                EntitySingleton.Context.MiembroCargoes.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<MiembroCargo>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroCargo>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroCargo> getRecords()
        {
            throw new NotImplementedException();
        }

        public Operation<MiembroCargo> updateRecord(MiembroCargo o)
        {
            throw new NotImplementedException();
        }
    }
}
