//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegnalUDB.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventoSeccion
    {
        public int idEventoSeccion { get; set; }
        public int idEvento { get; set; }
        public int idSeccion { get; set; }
    
        public virtual Evento Evento { get; set; }
        public virtual Seccione Seccione { get; set; }
    }
}
