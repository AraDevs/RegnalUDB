using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;

namespace RegnalUDB.Controllers
{
    class MemberController : Controller<Miembro>
    {
        public Operation<Miembro> addRecord(Miembro o)
        {
            try
            {
                EntitySingleton.Context.Miembros.Add(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Miembro>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> deleteRecord(Miembro o)
        {
            throw new NotImplementedException();
        }

        public Operation<Miembro> getRecords()
        {
            try
            {
                List<Miembro> data = EntitySingleton.Context.Miembros.ToList();
                return FactoryOperation<Miembro>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> getRecordbyCum(string cum)
        {
            try
            {
                Miembro data = EntitySingleton.Context.Miembros.Where(x => x.cum == cum).FirstOrDefault();
                return FactoryOperation<Miembro>.getSingleValueOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }
        public Operation<Miembro> getLastRecord()
        {
            try
            {
                Miembro data = EntitySingleton.Context.Miembros.OrderByDescending(x => x.idMiembro).FirstOrDefault();
                return FactoryOperation<Miembro>.getSingleValueOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> getActiveRecordsByGroupAndEventAvailability(Grupos group, Evento ev)
        {
            try
            {
                List<Miembro> unfilteredData = EntitySingleton.Context.Miembros.Where(x => x.baja).ToList();

                List<Miembro> data = new List<Miembro>();

                List<Cargo> eventPositions = new List<Cargo>();
                foreach (EventoCargo ec in ev.EventoCargoes)
                {
                    eventPositions.Add(ec.Cargo);
                }

                foreach (Miembro member in unfilteredData)
                {
                    bool isInGroup = false;
                    bool sectionValid = false;
                    bool positionValid = false;
                    bool hasNoBlackList = true;

                    //Checking if the member is in the selected group
                    if (member.Grupos == group)
                    {
                        isInGroup = true;
                    }

                    //Checking if the member's section is applicable for the event
                    foreach (EventoSeccion es in ev.EventoSeccions)
                    {
                        if (member.Seccione == es.Seccione)
                        {
                            sectionValid = true;
                            break;
                        }
                    }

                    //Checking if one of the member's positions are apllicable for the event
                    foreach (MiembroCargo mc in member.MiembroCargoes)
                    {
                        if (eventPositions.Contains(mc.Cargo))
                        {
                            positionValid = true;
                            break;
                        }
                    }

                    //Checking if the user is banned
                    foreach (ListaNegra ln in member.ListaNegras1)
                    {
                        if (ln.baja)
                        {
                            hasNoBlackList = false;
                        }
                    }

                    //If all conditions are true, the member is applicable for the event
                    if (isInGroup && sectionValid && positionValid && hasNoBlackList)
                    {
                        data.Add(member);
                    }
                }
                
                return FactoryOperation<Miembro>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> updateRecord(Miembro o)
        {
            try
            {
                Miembro member = EntitySingleton.Context.Miembros.Find(o.idMiembro);
                EntitySingleton.Context.Entry(member).CurrentValues.SetValues(o);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<Miembro>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> getUnbannedMembers()
        {
            try
            {
                List<ListaNegra> bans = EntitySingleton.Context.ListaNegras.Where(ban => ban.baja).ToList();
                Func<Miembro, bool> CheckMember = member =>
                {
                    ListaNegra ban = bans.Find(b => b.Miembro.idMiembro == member.idMiembro);
                    return member.baja && ( ban == null || !ban.baja );
                };

                List<Miembro> data = EntitySingleton.Context.Miembros.Where(CheckMember).ToList();
                return FactoryOperation<Miembro>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }

        public Operation<Miembro> getActiveRecords()
        {
            try
            {
                List<Miembro> data = EntitySingleton.Context.Miembros.Where(member => member.baja).ToList();
                return FactoryOperation<Miembro>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<Miembro>.getFailOperation(e.Message);
            }
        }
    }
}
