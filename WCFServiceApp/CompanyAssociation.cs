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
    
    public partial class CompanyAssociation
    {
        public int CompanyAssociationID { get; set; }
        public int Company1ID { get; set; }
        public int Company2ID { get; set; }
        public string AssociationType { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Company Company1 { get; set; }
    }
}
