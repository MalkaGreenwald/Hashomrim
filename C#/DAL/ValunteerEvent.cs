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
    
    public partial class ValunteerEvent
    {
        public int valunteerId { get; set; }
        public int eventCodeId { get; set; }
        public Nullable<int> valunteerStatusInEventId { get; set; }
        public Nullable<System.DateTime> dateGetEvent { get; set; }
        public int id { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual ValunteerStatusInEvent ValunteerStatusInEvent { get; set; }
    }
}
