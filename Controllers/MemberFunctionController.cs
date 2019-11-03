using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class MemberFunctionController : Controller<MiembroFuncion>
    {
        public Operation<MiembroFuncion> addRecord(MiembroFuncion o)
        {
            try
            {
                EntitySingleton.Context.MiembroFuncions.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<MiembroFuncion>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroFuncion>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroFuncion> deleteRecord(MiembroFuncion o)
        {
            try
            {
                EntitySingleton.Context.MiembroFuncions.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<MiembroFuncion>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroFuncion>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroFuncion> getRecords()
        {
            try
            {
                List<MiembroFuncion> data = EntitySingleton.Context.MiembroFuncions.ToList();
                return FactoryOperation<MiembroFuncion>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroFuncion>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroFuncion> getRecordsByMember(Miembro mem)
        {
            try
            {
                List<MiembroFuncion> data = EntitySingleton.Context.MiembroFuncions.Where(x => x.idMiembro == mem.idMiembro).ToList();
                return FactoryOperation<MiembroFuncion>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroFuncion>.getFailOperation(e.Message);
            }
        }

        public Operation<MiembroFuncion> updateRecord(MiembroFuncion o)
        {
            try
            {
                MiembroFuncion mf = EntitySingleton.Context.MiembroFuncions.Find(o.idMiembroFuncion);
                EntitySingleton.Context.Entry(mf).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<MiembroFuncion>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<MiembroFuncion>.getFailOperation(e.Message);
            }
        }
    }
}
