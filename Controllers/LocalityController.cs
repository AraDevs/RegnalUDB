using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                EntitySingleton.Context.Localidades.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Localidade>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Localidade>.getFailOperation(e.Message);
            }
        }

        public Operation<Localidade> deleteRecord(Localidade o)
        {
            try
            {
                EntitySingleton.Context.Localidades.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Localidade>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Localidade>.getFailOperation(e.Message);
            }
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

        public Operation<Localidade> getActiveRecords()
        {
            try
            {
                List<Localidade> data = EntitySingleton.Context.Localidades.Where(x => x.baja).ToList();
                return FactoryOperation<Localidade>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Localidade>.getFailOperation(e.Message);
            }
        }

        public Operation<Localidade> updateRecord(Localidade o)
        {
            try
            {
                Localidade localidade = EntitySingleton.Context.Localidades.Find(o.idLocalidad);
                EntitySingleton.Context.Entry(localidade).CurrentValues.SetValues(o);

                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Localidade>.getSuccessOperation();
            }
            catch(Exception e)
            {                
                return FactoryOperation<Localidade>.getFailOperation(e.Message);
            }
        }
    }
}
