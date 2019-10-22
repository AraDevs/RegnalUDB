using System;
using System.Collections.Generic;
using System.Linq;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class AdvertisementsController : Controller<Anuncio>
    {
        public Operation<Anuncio> addRecord(Anuncio o)
        {
            try
            {
                EntitySingleton.Context.Anuncios.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Anuncio>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Anuncio>.getFailOperation(e.Message);
            }
        }

        public Operation<Anuncio> deleteRecord(Anuncio o)
        {
            try
            {
                EntitySingleton.Context.Anuncios.Remove(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Anuncio>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Anuncio>.getFailOperation(e.Message);
            }
        }

        public Operation<Anuncio> getRecords()
        {
            try
            {
                List<Anuncio> data = EntitySingleton.Context.Anuncios.ToList();
                return FactoryOperation<Anuncio>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Anuncio>.getFailOperation(e.Message);
            }
        }

        public Operation<Anuncio> updateRecord(Anuncio o)
        {
            try
            {
                Anuncio advertisement = EntitySingleton.Context.Anuncios.Find(o.idAnuncio);
                EntitySingleton.Context.Entry(advertisement).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Anuncio>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Anuncio>.getFailOperation(e.Message);
            }
        }
    }
}
