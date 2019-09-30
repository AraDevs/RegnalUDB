using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class MemberController : Controller<Miembro>
    {
        public Operation<Miembro> addRecord(Miembro o)
        {
            try
            {
                EntitySingleton.Context.Miembros.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Miembro>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> deleteRecord(Miembro o)
        {
            throw new NotImplementedException();
        }

        public Operation<Miembro> getRecords()
        {
            try
            {
                List<Miembro> data = EntitySingleton.Context.Miembros.ToList();
                return FactoryOperation<Miembro>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> getRecordbyCum(string cum)
        {
            try
            {
                Miembro data = EntitySingleton.Context.Miembros.Where(x => x.cum == cum).FirstOrDefault();
                return FactoryOperation<Miembro>.getSingleValueOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }
        public Operation<Miembro> getLastRecord()
        {
            try
            {
                Miembro data = EntitySingleton.Context.Miembros.OrderByDescending(x => x.idMiembro).FirstOrDefault();
                return FactoryOperation<Miembro>.getSingleValueOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> updateRecord(Miembro o)
        {
            try
            {
                Miembro member = EntitySingleton.Context.Miembros.Find(o.idMiembro);
                EntitySingleton.Context.Entry(member).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Miembro>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }
    }
}
