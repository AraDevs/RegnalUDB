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
    
    public partial class EventosFuncione
    {
        public int idEventosFunciones { get; set; }
        public int idFuncion { get; set; }
        public int idEvento { get; set; }
    
        public virtual Evento Evento { get; set; }
        public virtual Funcione Funcione { get; set; }
    }
}
