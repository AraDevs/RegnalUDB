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
    
    public partial class MiembroCargo
    {
        public int idMiembroCargo { get; set; }
        public int idMembro { get; set; }
        public int idCargo { get; set; }
        public System.DateTime fecha { get; set; }
    
        public virtual Cargo Cargo { get; set; }
        public virtual Miembro Miembro { get; set; }
    }
}