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
    
    public partial class SecurityGroup
    {
        public SecurityGroup()
        {
            this.Deals = new HashSet<Deal>();
        }
    
        public int SecurityGroupID { get; set; }
        public int SecurityID1 { get; set; }
        public Nullable<int> SecurityID2 { get; set; }
        public Nullable<int> SecurityID3 { get; set; }
        public Nullable<int> SecurityID4 { get; set; }
        public Nullable<int> SecurityID5 { get; set; }
    
        private ICollection<Deal> Deals { get; set; }
        public virtual Security Security { get; set; }
        private Security Security1 { get; set; }
        private Security Security2 { get; set; }
        private Security Security3 { get; set; }
        private Security Security4 { get; set; }
    }
}
