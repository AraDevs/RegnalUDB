using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class MunicipalityContraller : Controller<Municipio>
    {
        public Operation<Municipio> addRecord(Municipio o)
        {
            throw new NotImplementedException();
        }

        public Operation<Municipio> deleteRecord(Municipio o)
        {
            throw new NotImplementedException();
        }

        public Operation<Municipio> getRecords()
        {
            try
            {
                List<Municipio> data = EntitySingleton.Context.Municipios.ToList();
                return FactoryOperation<Municipio>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Municipio>.getFailOperation(e.Message);
            }
        }

        public Operation<Municipio> getRecordsByDepartment(Departamento department)
        {
            try
            {
                List<Municipio> data = EntitySingleton.Context.Municipios.
                    Where(x => x.idDepartamento.Equals(department.idDepartamento)).ToList();
                return FactoryOperation<Municipio>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Municipio>.getFailOperation(e.Message);
            }
        }

        public Operation<Municipio> updateRecord(Municipio o)
        {
            throw new NotImplementedException();
        }
    }
}
