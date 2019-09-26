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
    
    public partial class Cargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cargo()
        {
            this.EventoCargoes = new HashSet<EventoCargo>();
            this.MiembroCargoes = new HashSet<MiembroCargo>();
        }
    
        public int idCargo { get; set; }
        public string nombre { get; set; }
        public string siglas { get; set; }
        public short total { get; set; }
        public Nullable<short> baja { get; set; }
        public int idNivel { get; set; }
        public int idPerfil { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventoCargo> EventoCargoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MiembroCargo> MiembroCargoes { get; set; }
    }
}