using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class GroupController : Controller<Grupos>
    {
        public Operation<Grupos> addRecord(Grupos o)
        {
            try
            {
                EntitySingleton.Context.Grupos.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Grupos>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Grupos>.getFailOperation(e.Message);
            }
        }

        public Operation<Grupos> deleteRecord(Grupos o)
        {
            try
            {
                EntitySingleton.Context.Grupos.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Grupos>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Grupos>.getFailOperation(e.Message);
            }
        }

        public Operation<Grupos> getRecords()
        {
            try
            {
                List<Grupos> data = EntitySingleton.Context.Grupos.Where(g=> g.baja).ToList();
                return FactoryOperation<Grupos>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Grupos>.getFailOperation(e.Message);
            }
        }

        public Operation<Grupos> updateRecord(Grupos o)
        {
            try
            {
                Grupos group = EntitySingleton.Context.Grupos.Find(o.idGrupo);
                EntitySingleton.Context.Entry(group).CurrentValues.SetValues(o);

                group.Localidade = o.Localidade;
                group.Distrito = o.Distrito;

                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Grupos>.getSuccessOperation();
            }
            catch (Exception e)
            {
                Trace.Write(e.InnerException);
                return FactoryOperation<Grupos>.getFailOperation(e.Message);
            }
        }
    }
}
