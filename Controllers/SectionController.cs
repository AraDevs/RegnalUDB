using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class SectionController : Controller<Seccione>
    {
        public Operation<Seccione> addRecord(Seccione o)
        {
            try
            {
                EntitySingleton.Context.Secciones.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Seccione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Seccione>.getFailOperation(e.Message);
            }
        }

        /*Delete is not contempled in the program flow*/
        public Operation<Seccione> deleteRecord(Seccione o)
        {
            try
            {
                EntitySingleton.Context.Secciones.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Seccione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Seccione>.getFailOperation(e.Message);
            }
        }

        public Operation<Seccione> getRecords()
        {
            try
            {
                List<Seccione> data = EntitySingleton.Context.Secciones.ToList();
                return FactoryOperation<Seccione>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Seccione>.getFailOperation(e.Message);
            }
        }

        public Operation<Seccione> updateRecord(Seccione o)
        {
            try
            {
                Seccione section = EntitySingleton.Context.Secciones.Find(o.idSeccion);
                EntitySingleton.Context.Entry(section).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Seccione>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Seccione>.getFailOperation(e.Message);
            }
        }
    }
}
