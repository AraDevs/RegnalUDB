using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class DomicileController : Controller<Domicilio>
    {
        public Operation<Domicilio> addRecord(Domicilio o)
        {
            try
            {
                EntitySingleton.Context.Domicilios.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Domicilio>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Domicilio>.getFailOperation(e.Message);
            }
        }

        public Operation<Domicilio> deleteRecord(Domicilio o)
        {
            throw new NotImplementedException();
        }

        public Operation<Domicilio> getRecords()
        {
            try
            {
                List<Domicilio> data = EntitySingleton.Context.Domicilios.ToList();
                return FactoryOperation<Domicilio>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Domicilio>.getFailOperation(e.Message);
            }
        }

        public Operation<Domicilio> getLastRecord()
        {
            try
            {
                Domicilio data = EntitySingleton.Context.Domicilios.OrderByDescending(x => x.idDomicilio).FirstOrDefault();
                return FactoryOperation<Domicilio>.getSingleValueOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Domicilio>.getFailOperation(e.Message);
            }
        }
        public Operation<Domicilio> getRecordByMember(Miembro miembro)
        {
            try
            {
                Domicilio data = (Domicilio)EntitySingleton.Context.Domicilios.Where(x => x.idDomicilio == miembro.Domicilio.idDomicilio);
                return FactoryOperation<Domicilio>.getSingleValueOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Domicilio>.getFailOperation(e.Message);
            }
        }

        public Operation<Domicilio> updateRecord(Domicilio o)
        {
            throw new NotImplementedException();
        }
    }
}
