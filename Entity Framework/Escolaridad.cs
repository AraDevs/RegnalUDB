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
    
    public partial class Escolaridad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Escolaridad()
        {
            this.Miembros = new HashSet<Miembro>();
        }
    
        public int idEscolaridad { get; set; }
        public string grado { get; set; }
        public bool baja { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembro> Miembros { get; set; }
    }
}
