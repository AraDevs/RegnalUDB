using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    class BlackListController : Controller<ListaNegra>
    {
        public Operation<ListaNegra> addRecord(ListaNegra o)
        {

            try
            {
                EntitySingleton.Context.ListaNegras.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<ListaNegra>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<ListaNegra>.getFailOperation(e.Message);
            }
        }

        public Operation<ListaNegra> getRecords()
        {
            try
            {
                List<ListaNegra> data = EntitySingleton.Context.ListaNegras.ToList();
                return FactoryOperation<ListaNegra>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<ListaNegra>.getFailOperation(e.Message);
            }
        }

        public Operation<ListaNegra> getBansByResponsableAndMember(int responsable, int member)
        {
            try
            {
                List<ListaNegra> data = EntitySingleton.Context.ListaNegras
                    .Where(ban => ban.idMiembro == member && ban.responsable == responsable && ban.baja).ToList();
                return FactoryOperation<ListaNegra>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<ListaNegra>.getFailOperation(e.Message);
            }
        }
        public Operation<ListaNegra> updateRecord(ListaNegra o)
        {
            try
            {
                ListaNegra blackList = EntitySingleton.Context.ListaNegras.Find(o.idListaNegra);
                EntitySingleton.Context.Entry(blackList).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<ListaNegra>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<ListaNegra>.getFailOperation(e.Message);
            }
        }



        Operation<ListaNegra> Controller<ListaNegra>.deleteRecord(ListaNegra o)
        {
            throw new NotImplementedException();
        }
    }
}
