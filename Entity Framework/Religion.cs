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
    
    public partial class Religion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Religion()
        {
            this.Miembros = new HashSet<Miembro>();
        }
    
        public int idReligion { get; set; }
        public string nombre { get; set; }
        public bool baja { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembro> Miembros { get; set; }
    }
}
