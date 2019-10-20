using System;
using System.Collections.Generic;
using System.Linq;
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
        public Operation<Seccione> getRecordsByMemberInfo(string gender, int age)
        {
            try
            {
                //Obtaining the upper age limit of the section in which the member can be assigned by default
                int? upper = EntitySingleton.Context.Secciones.Where(x => (x.rangoFin >= age && x.rangoInicio <= age) || (x.rangoFin == null && x.rangoInicio <= age) && x.baja).FirstOrDefault().rangoFin;

                List<Seccione> data;

                //If the upper age limit is null, it is already in the maximum level of sections
                if (upper == null)
                {
                    data = EntitySingleton.Context.Secciones.
                        Where(x => x.sexo.Equals(gender) && x.rangoFin == null && x.rangoInicio <= age && x.baja).ToList();
                }
                //If the upper age limit is not null, it will return the section(s) in which the member can be
                //assigned by its age, plus the section corresponding to its next level
                else
                {
                    data = EntitySingleton.Context.Secciones.
                        Where(x => x.sexo.Equals(gender) &&
                        ((x.rangoFin >= age && x.rangoInicio <= age) || x.rangoInicio == (upper + 1)) && x.baja).ToList();
                }

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
