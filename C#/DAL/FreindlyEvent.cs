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
    
    public partial class FreindlyEvent
    {
        public int freindlyCode { get; set; }
        public string freindlyDescription { get; set; }
        public Nullable<double> heightPointAddress { get; set; }
        public Nullable<double> widthPointAddress { get; set; }
        public Nullable<System.TimeSpan> hour { get; set; }
        public Nullable<int> countValunteer { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> city { get; set; }
        public string addressFreindlyEvent { get; set; }
    }
}