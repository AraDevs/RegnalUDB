using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class DepartmentController : Controller<Departamento>
    {
        public Operation<Departamento> addRecord(Departamento o)
        {
            try
            {
                EntitySingleton.Context.Departamentos.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Departamento>.getSuccessOperation();
            }
            catch(Exception e)
            {
                return FactoryOperation<Departamento>.getFailOperation(e.Message);
            }
        }

        public Operation<Departamento> deleteRecord(Departamento o)
        {
            throw new NotImplementedException();
        }

        public Operation<Departamento> getRecords()
        {
            try
            {
                List<Departamento> data = EntitySingleton.Context.Departamentos.ToList();
                return FactoryOperation<Departamento>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Departamento>.getFailOperation(e.Message);
            }
        }

        public Operation<Departamento> getActiveRecords()
        {
            try
            {
                List<Departamento> data = EntitySingleton.Context.Departamentos.Where(x => x.baja).ToList();
                return FactoryOperation<Departamento>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Departamento>.getFailOperation(e.Message);
            }
        }

        public Operation<Departamento> updateRecord(Departamento o)
        {
            try
            {
                Departamento departamento = EntitySingleton.Context.Departamentos.Find(o.idDepartamento);
                EntitySingleton.Context.Entry(departamento).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Departamento>.getSuccessOperation();
            }
            catch(Exception e)
            {
                return FactoryOperation<Departamento>.getFailOperation(e.Message);
            }
        }
    }
}
