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
    
    public partial class Valunteer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Valunteer()
        {
            this.HistoryStatusValunteers = new HashSet<HistoryStatusValunteer>();
        }
    
        public string tz { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public Nullable<int> cityId { get; set; }
        public Nullable<double> hieghtPointAddress { get; set; }
        public Nullable<int> personalSituationId { get; set; }
        public Nullable<double> widthPointAddress { get; set; }
        public Nullable<int> volunteerDetailId { get; set; }
        public int id { get; set; }
        public string addressVolunteer { get; set; }
    
        public virtual DetailsValunteer DetailsValunteer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryStatusValunteer> HistoryStatusValunteers { get; set; }
        public virtual PersonalSituation PersonalSituation { get; set; }
    }
}