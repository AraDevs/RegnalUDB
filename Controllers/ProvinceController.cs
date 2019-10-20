using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class ProvinceController : Controller<Provincia>
    {
        public Operation<Provincia> addRecord(Provincia o)
        {
            try
            {
                EntitySingleton.Context.Provincias.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Provincia>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Provincia>.getFailOperation(e.Message);
            }
        }

        public Operation<Provincia> deleteRecord(Provincia o)
        {
            throw new NotImplementedException();
        }

        public Operation<Provincia> getRecords()
        {

            try
            {
                List<Provincia> data = EntitySingleton.Context.Provincias.ToList();
                return FactoryOperation<Provincia>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Provincia>.getFailOperation(e.Message);
            }
        }

        public Operation<Provincia> getActiveRecords()
        {

            try
            {
                List<Provincia> data = EntitySingleton.Context.Provincias.Where(x => x.baja).ToList();
                return FactoryOperation<Provincia>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Provincia>.getFailOperation(e.Message);
            }
        }

        public Operation<Provincia> updateRecord(Provincia o)
        {
            try
            {
                Provincia province = EntitySingleton.Context.Provincias.Find(o.idProvincia);
                EntitySingleton.Context.Entry(province).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Provincia>.getSuccessOperation();
            }
            catch (Exception e)
            {
                Trace.Write(e.InnerException);
                return FactoryOperation<Provincia>.getFailOperation(e.Message);
            }
        }
    }
}
