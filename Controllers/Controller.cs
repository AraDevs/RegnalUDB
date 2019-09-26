using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Controllers
{
    interface Controller<T>
    {
        void saveRegister(T o);
        List<T> getRegisters();
    }
}
