//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceLibraryTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        public Company()
        {
            this.CompanyAssociations = new HashSet<CompanyAssociation>();
            this.CompanyAssociations1 = new HashSet<CompanyAssociation>();
            this.Deals = new HashSet<Deal>();
            this.Deals1 = new HashSet<Deal>();
            this.Deals2 = new HashSet<Deal>();
        }
    
        public int CompanyID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        private ICollection<CompanyAssociation> CompanyAssociations { get; set; }
        private ICollection<CompanyAssociation> CompanyAssociations1 { get; set; }
        private ICollection<Deal> Deals { get; set; }
        private ICollection<Deal> Deals1 { get; set; }
        private ICollection<Deal> Deals2 { get; set; }
    }
}
