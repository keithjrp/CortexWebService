//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CortexWebService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public Event()
        {
            this.Deals = new HashSet<Deal>();
            this.Deals1 = new HashSet<Deal>();
            this.Deals2 = new HashSet<Deal>();
            this.Deals3 = new HashSet<Deal>();
        }
    
        public int EventID { get; set; }
        public string Description { get; set; }
        public System.DateTime EventDate { get; set; }
        public int EventTypeID { get; set; }
        public string Note { get; set; }
        public Nullable<int> DealID { get; set; }
    
        public virtual ICollection<Deal> Deals { get; set; }
        public virtual ICollection<Deal> Deals1 { get; set; }
        public virtual ICollection<Deal> Deals2 { get; set; }
        public virtual ICollection<Deal> Deals3 { get; set; }
        public virtual Deal Deal { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
