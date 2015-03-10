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
    
    public partial class Security
    {
        public Security()
        {
            this.SecurityGroups = new HashSet<SecurityGroup>();
            this.SecurityGroups1 = new HashSet<SecurityGroup>();
            this.SecurityGroups2 = new HashSet<SecurityGroup>();
            this.SecurityGroups3 = new HashSet<SecurityGroup>();
            this.SecurityGroups4 = new HashSet<SecurityGroup>();
            this.Companies = new HashSet<Company>();
            this.Prices = new HashSet<Price>();
        }
    
        public int SecurityID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SecurityTypeID { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public string Cusip { get; set; }
        public string Isin { get; set; }
        public string Sedol { get; set; }
        public string Ticker { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual ICollection<SecurityGroup> SecurityGroups { get; set; }
        public virtual ICollection<SecurityGroup> SecurityGroups1 { get; set; }
        public virtual ICollection<SecurityGroup> SecurityGroups2 { get; set; }
        public virtual ICollection<SecurityGroup> SecurityGroups3 { get; set; }
        public virtual ICollection<SecurityGroup> SecurityGroups4 { get; set; }
        public virtual SecurityType SecurityType { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
