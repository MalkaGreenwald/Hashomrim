//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailsValunteer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DetailsValunteer()
        {
            this.Valunteers = new HashSet<Valunteer>();
        }
    
        public int statusValunteerId { get; set; }
        public System.DateTime silencingRingingUntilDate { get; set; } = new DateTime();
        public Nullable<System.DateTime> silencingRingingFronDate { get; set; }
        public int id { get; set; }
        public Nullable<int> radius { get; set; }
    
        public virtual StatusValunteer StatusValunteer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Valunteer> Valunteers { get; set; }
    }
}