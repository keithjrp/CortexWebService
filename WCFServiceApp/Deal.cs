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
    
    public partial class Deal
    {
        public Deal()
        {
            this.MapDealAnalysts = new HashSet<MapDealAnalyst>();
            this.Events = new HashSet<Event>();
            this.Documents = new HashSet<Document>();
        }
    
        public int DealID { get; set; }
        public string Description { get; set; }
        public Nullable<int> SecurityGroupID { get; set; }
        public Nullable<int> CompanyID1 { get; set; }
        public Nullable<int> CompanyID2 { get; set; }
        public Nullable<int> CompanyID3 { get; set; }
        public string InvestmentThesis { get; set; }
        public Nullable<int> MergerAgreementEventID { get; set; }
        public Nullable<int> DropDeadEventID { get; set; }
        public Nullable<int> TargetShareholderMeetingEventID { get; set; }
        public Nullable<int> AcquirerShareholderMeetingEventID { get; set; }
        public Nullable<decimal> TargetPrice { get; set; }
        public string Recommendation { get; set; }
        public Nullable<int> DealCurrencyID { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public Nullable<int> DocumentGroupID { get; set; }
        public string TargetPriceValuation { get; set; }
        public string CurrentValuation { get; set; }
        public string Catalyst { get; set; }
        public string KeyRisks { get; set; }
        public string ValuationMethodology { get; set; }
        public string Background { get; set; }
        public Nullable<decimal> DownsidePrice { get; set; }
        public string DownsidePriceValuation { get; set; }
        public string Comps { get; set; }
        public Nullable<int> DealTypeID { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> DealStatusID { get; set; }
        public Nullable<int> CategoryID { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Company Company1 { get; set; }
        public virtual Company Company2 { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Event Event { get; set; }
        public virtual Event Event1 { get; set; }
        public virtual Event Event2 { get; set; }
        public virtual Event Event3 { get; set; }
        public virtual Deal Deals1 { get; set; }
        public virtual Deal Deal1 { get; set; }
        public virtual DocumentGroup DocumentGroup { get; set; }
        public virtual SecurityGroup SecurityGroup { get; set; }
        public virtual DealType DealType { get; set; }
        public virtual DealType DealType1 { get; set; }
        public virtual Category Category { get; set; }
        public virtual DealStatus DealStatus { get; set; }
        public virtual ICollection<MapDealAnalyst> MapDealAnalysts { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}