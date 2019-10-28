using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class ProfileController : Controller<Perfile>
    {
        public Operation<Perfile> addRecord(Perfile o)
        {
            try
            {
                EntitySingleton.Context.Perfiles.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Perfile>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Perfile>.getFailOperation(e.Message);
            }
        }

        public Operation<Perfile> deleteRecord(Perfile o)
        {
            throw new NotImplementedException();
        }

        public Operation<Perfile> getRecords()
        {
            try
            {
                List<Perfile> data = EntitySingleton.Context.Perfiles.ToList();
                return FactoryOperation<Perfile>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Perfile>.getFailOperation(e.Message);
            }
        }

        public Operation<Perfile> updateRecord(Perfile o)
        {
            try
            {
                Perfile perfil = EntitySingleton.Context.Perfiles.Find(o.idPerfil);
                EntitySingleton.Context.Entry(perfil).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Perfile>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Perfile>.getFailOperation(e.Message);
            }
        }
    }
}
