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
    
    public partial class Document
    {
        public Document()
        {
            this.DocumentGroups = new HashSet<DocumentGroup>();
            this.DocumentGroups1 = new HashSet<DocumentGroup>();
            this.DocumentGroups2 = new HashSet<DocumentGroup>();
        }
    
        public int DocumentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URI { get; set; }
        public Nullable<int> DealId { get; set; }
    
        public virtual ICollection<DocumentGroup> DocumentGroups { get; set; }
        public virtual ICollection<DocumentGroup> DocumentGroups1 { get; set; }
        public virtual ICollection<DocumentGroup> DocumentGroups2 { get; set; }
        public virtual Deal Deal { get; set; }
    }
}
