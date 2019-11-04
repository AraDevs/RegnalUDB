using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;

namespace RegnalUDB.Controllers
{
    class UserController : Controller<Usuario>
    {
        public Operation<Usuario> addRecord(Usuario o)
        {
            try
            {
                EntitySingleton.Context.Usuarios.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Usuario>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Usuario>.getFailOperation(e.Message);
            }
        }

        public Operation<Usuario> deleteRecord(Usuario o)
        {
            throw new NotImplementedException();
        }

        public Operation<Usuario> getRecords()
        {
            try
            {
                List<Usuario> data = EntitySingleton.Context.Usuarios.ToList();
                return FactoryOperation<Usuario>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Usuario>.getFailOperation(e.Message);
            }
        }

        public Operation<Usuario> updateRecord(Usuario o)
        {
            try
            {
                Usuario user = EntitySingleton.Context.Usuarios.Find(o.idUsuario);
                EntitySingleton.Context.Entry(user).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Usuario>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Usuario>.getFailOperation(e.Message);
            }
        }

        public Operation<Usuario> login(string cum, string pass)
        {
            try
            {
                String password = EncriptionUtils.MD5Hash(pass);
                Usuario data = EntitySingleton.Context.Usuarios.Where(u=>u.Miembro.cum == cum && u.pass == password).FirstOrDefault();
                return FactoryOperation<Usuario>.getSingleValueOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Usuario>.getFailOperation(e.Message);
            }
        }
    }
}
