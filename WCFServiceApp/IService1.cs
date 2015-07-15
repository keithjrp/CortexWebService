// ***********************************************************************
// Assembly         : CortexWebService
// Author           : ktam
// Created          : 12-16-2014
//
// Last Modified By : ktam
// Last Modified On : 03-25-2015
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

/// <summary>
/// The CortexWebService namespace.
/// </summary>
namespace CortexWebService
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    /// <summary>
    /// Interface CortexWCFService
    /// </summary>
    [ServiceContract]
    public interface CortexWCFService
    {

        /// <summary>
        /// Gets the deal.
        /// </summary>
        /// <param name="DealId">The deal identifier.</param>
        /// <returns>Deal.</returns>
        [OperationContract]
        Deal getDeal(int DealId);

        /// <summary>
        /// Gets the deals.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDeals(int count = 30);

        /// <summary>
        /// Adds the deal.
        /// </summary>
        /// <param name="d">The d.</param>
        [OperationContract]
        void addDeal(Deal d);

        /// <summary>
        /// Removes the deal.
        /// </summary>
        /// <param name="d">The d.</param>
        [OperationContract]
        void removeDeal(Deal d);

        /// <summary>
        /// Updates the deal.
        /// </summary>
        /// <param name="d">The d.</param>
        [OperationContract]
        void updateDeal(Deal d);

        /// <summary>
        /// Gets the deals by description.
        /// </summary>
        /// <param name="desc">The desc.</param>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDealsByDescription(String desc);

        /// <summary>
        /// Gets the deal by date.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns>Deal.</returns>
        [OperationContract]
        Deal getDealByDate(DateTime dt);

        /// <summary>
        /// Removes the deal by identifier.
        /// </summary>
        /// <param name="DealId">The deal identifier.</param>
        [OperationContract]
        void removeDealById(int DealId);

        /// <summary>
        /// Removes the deal by description.
        /// </summary>
        /// <param name="desc">The desc.</param>
        [OperationContract]
        void removeDealByDescription(String desc);

        /// <summary>
        /// Gets the security.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Security.</returns>
        [OperationContract]
        Security getSecurity(int id);

        /// <summary>
        /// Adds the security.
        /// </summary>
        /// <param name="sec">The sec.</param>
        [OperationContract]
        void addSecurity(Security sec);

        /// <summary>
        /// Updates the security.
        /// </summary>
        /// <param name="sec">The sec.</param>
        [OperationContract]
        void updateSecurity(Security sec);

        /// <summary>
        /// Removes the security.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [OperationContract]
        void removeSecurity(int id);

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Company.</returns>
        [OperationContract]
        Company getCompany(int id);

        /// <summary>
        /// Adds the company.
        /// </summary>
        /// <param name="sec">The sec.</param>
        [OperationContract]
        void addCompany(Company sec);

        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="sec">The sec.</param>
        [OperationContract]
        void updateCompany(Company sec);

        /// <summary>
        /// Removes the company.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [OperationContract]
        void removeCompany(int id);

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Document.</returns>
        [OperationContract]
        Document getDocument(int id);

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Currency.</returns>
        [OperationContract]
        Currency getCurrency(int id);

        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Event.</returns>
        [OperationContract]
        Event getEvent(int id);

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EventType.</returns>
        [OperationContract]
        EventType getEventType(int id);

        /// <summary>
        /// Gets the document group.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DocumentGroup.</returns>
        [OperationContract]
        DocumentGroup getDocumentGroup(int id);

        /// <summary>
        /// Gets the security group.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SecurityGroup.</returns>
        [OperationContract]
        SecurityGroup getSecurityGroup(int id);

        /// <summary>
        /// Gets the type of the security.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SecurityType.</returns>
        [OperationContract]
        SecurityType getSecurityType(int id);

        /// <summary>
        /// Gets the company association.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CompanyAssociation.</returns>
        [OperationContract]
        CompanyAssociation getCompanyAssociation(int id);

        /// <summary>
        /// Removes the company association.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [OperationContract]
        void removeCompanyAssociation(int id);

        /// <summary>
        /// Updates the company association.
        /// </summary>
        /// <param name="ca">The ca.</param>
        [OperationContract]
        void updateCompanyAssociation(CompanyAssociation ca);

        /// <summary>
        /// Adds the company association.
        /// </summary>
        /// <param name="ca">The ca.</param>
        [OperationContract]
        void addCompanyAssociation(CompanyAssociation ca);

        /// <summary>
        /// Gets the last company.
        /// </summary>
        /// <returns>Company.</returns>
        [OperationContract]
        Company getLastCompany();

        /// <summary>
        /// Gets the last company association.
        /// </summary>
        /// <returns>CompanyAssociation.</returns>
        [OperationContract]
        CompanyAssociation getLastCompanyAssociation();

        /// <summary>
        /// Gets the last security.
        /// </summary>
        /// <returns>Security.</returns>
        [OperationContract]
        Security getLastSecurity();

        /// <summary>
        /// Gets the last security group.
        /// </summary>
        /// <returns>SecurityGroup.</returns>
        [OperationContract]
        SecurityGroup getLastSecurityGroup();

        /// <summary>
        /// Adds the security group.
        /// </summary>
        /// <param name="newSG">The new sg.</param>
        [OperationContract]
        void addSecurityGroup(SecurityGroup newSG);

        /// <summary>
        /// Adds the document group.
        /// </summary>
        /// <param name="newDG">The new dg.</param>
        [OperationContract]
        void addDocumentGroup(DocumentGroup newDG);

        /// <summary>
        /// Gets the name of the currency by code or.
        /// </summary>
        /// <param name="codename">The codename.</param>
        /// <returns>Currency.</returns>
        [OperationContract]
        Currency getCurrencyByCodeOrName(String codename);

        /// <summary>
        /// Gets the last document group.
        /// </summary>
        /// <returns>DocumentGroup.</returns>
        [OperationContract]
        DocumentGroup getLastDocumentGroup();

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Price.</returns>
        [OperationContract]
        Price getPrice(int pid);

        /// <summary>
        /// Gets the type of the statistic.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>StatisticType.</returns>
        [OperationContract]
        StatisticType getStatisticType(int id);

        /// <summary>
        /// Gets the annual company statistic.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>AnnualCompanyStatistic.</returns>
        [OperationContract]
        AnnualCompanyStatistic getAnnualCompanyStatistic(int id);

        /// <summary>
        /// Gets the type of the deal.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>DealType.</returns>
        [OperationContract]
        DealType getDealType(int pid);

        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="c">The c.</param>
        [OperationContract]
        void addCurrency(Currency c);

        /// <summary>
        /// Adds the document.
        /// </summary>
        /// <param name="d">The d.</param>
        [OperationContract]
        void addDocument(Document d);

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="e">The e.</param>
        [OperationContract]
        void addEvent(Event e);

        /// <summary>
        /// Adds the type of the event.
        /// </summary>
        /// <param name="e">The e.</param>
        [OperationContract]
        void addEventType(EventType e);

        /// <summary>
        /// Adds the price.
        /// </summary>
        /// <param name="p">The p.</param>
        [OperationContract]
        void addPrice(Price p);

        /// <summary>
        /// Adds the annual company statistic.
        /// </summary>
        /// <param name="acs">The acs.</param>
        [OperationContract]
        void addAnnualCompanyStatistic(AnnualCompanyStatistic acs);

        /// <summary>
        /// Adds the type of the statistic.
        /// </summary>
        /// <param name="st">The st.</param>
        [OperationContract]
        void addStatisticType(StatisticType st);

        /// <summary>
        /// Adds the type of the deal.
        /// </summary>
        /// <param name="dt">The dt.</param>
        [OperationContract]
        void addDealType(DealType dt);

        /// <summary>
        /// Adds the type of the security.
        /// </summary>
        /// <param name="st">The st.</param>
        [OperationContract]
        void addSecurityType(SecurityType st);

        /// <summary>
        /// Updates the document group.
        /// </summary>
        /// <param name="dg">The dg.</param>
        [OperationContract]
        void updateDocumentGroup(DocumentGroup dg);

        /// <summary>
        /// Updates the security group.
        /// </summary>
        /// <param name="sg">The sg.</param>
        [OperationContract]
        void updateSecurityGroup(SecurityGroup sg);

        /// <summary>
        /// Gets the name of the document by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Document.</returns>
        [OperationContract]
        Document getDocumentByName(String name);

        /// <summary>
        /// Updates the document.
        /// </summary>
        /// <param name="d">The d.</param>
        [OperationContract]
        void updateDocument(Document d);

        /// <summary>
        /// Gets the last document.
        /// </summary>
        /// <returns>Document.</returns>
        [OperationContract]
        Document getLastDocument();

        /// <summary>
        /// Gets the deal by company.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDealByCompany(Company c);

        /// <summary>
        /// Gets the deal list.
        /// </summary>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDealList();

        /// <summary>
        /// Gets the analyst.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Analyst.</returns>
        [OperationContract]
        Analyst getAnalyst(int id);

        /// <summary>
        /// Gets the name of the analyst by.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>Analyst.</returns>
        [OperationContract]
        Analyst getAnalystByName(String login);

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <returns>System.String.</returns>
        [OperationContract]
        string GetCurrentDate();

        /// <summary>
        /// Gets the deal status.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DealStatus.</returns>
        [OperationContract]
        DealStatus getDealStatus(int id);

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Category.</returns>
        [OperationContract]
        Category getCategory(int id);

        /// <summary>
        /// Gets the deal team.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List&lt;MapDealAnalyst&gt;.</returns>
        [OperationContract]
        List<MapDealAnalyst> getDealTeam(int id);

        /// <summary>
        /// Updates the map deal analyst.
        /// </summary>
        /// <param name="mda">The mda.</param>
        [OperationContract]
        void updateMapDealAnalyst(MapDealAnalyst mda);

        /// <summary>
        /// Adds the map deal analyst.
        /// </summary>
        /// <param name="mda">The mda.</param>
        [OperationContract]
        void addMapDealAnalyst(MapDealAnalyst mda);

        /// <summary>
        /// Gets the map deal analyst.
        /// </summary>
        /// <param name="DealId">The deal identifier.</param>
        /// <param name="AnalystId">The analyst identifier.</param>
        /// <returns>MapDealAnalyst.</returns>
        [OperationContract]
        MapDealAnalyst getMapDealAnalyst(int DealId, int AnalystId);

        /// <summary>
        /// Gets the deal by analyst.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDealByAnalyst(Analyst m);

        /// <summary>
        /// Gets the events by deal.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns>List&lt;Event&gt;.</returns>
        [OperationContract]
        List<Event> getEventsByDeal(int d);

        /// <summary>
        /// Gets the documents by deal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List&lt;Document&gt;.</returns>
        [OperationContract]
        List<Document> getDocumentsByDeal(int id);

        /// <summary>
        /// Gets the last event.
        /// </summary>
        /// <returns>Event.</returns>
        [OperationContract]
        Event getLastEvent();

        /// <summary>
        /// Removes the event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [OperationContract]
        void removeEvent(int id);

        /// <summary>
        /// Removes the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [OperationContract]
        void removeDocument(int id);

        /// <summary>
        /// Removes the map deal analyst.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [OperationContract]
        void removeMapDealAnalyst(int id);

        /// <summary>
        /// Audits the trail add.
        /// </summary>
        /// <param name="usr">The usr.</param>
        /// <param name="d">The d.</param>
        [OperationContract]
        void AuditTrailAdd(ApplicationUser usr, Deal d);

        /// <summary>
        /// Audits the trail update.
        /// </summary>
        /// <param name="usr">The usr.</param>
        /// <param name="d">The d.</param>
        [OperationContract]
        void AuditTrailUpdate(ApplicationUser usr, Deal d);

        /// <summary>
        /// Audits the trail delete.
        /// </summary>
        /// <param name="usr">The usr.</param>
        /// <param name="d">The d.</param>
        [OperationContract]
        void AuditTrailDelete(ApplicationUser usr, Deal d);

        /// <summary>
        /// Audits the trail login.
        /// </summary>
        /// <param name="usr">The usr.</param>
        [OperationContract]
        void AuditTrailLogin(ApplicationUser usr);

        /// <summary>
        /// Audits the trail logout.
        /// </summary>
        /// <param name="usr">The usr.</param>
        [OperationContract]
        void AuditTrailLogout(ApplicationUser usr);

        /// <summary>
        /// Audits the trail view.
        /// </summary>
        /// <param name="usr">The usr.</param>
        /// <param name="d">The d.</param>
        [OperationContract]
        void AuditTrailView(ApplicationUser usr, Deal d);

        /// <summary>
        /// Gets the deal by status.
        /// </summary>
        /// <param name="ds">The ds.</param>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDealByStatus(DealStatus ds);

        /// <summary>
        /// Gets the deals by category class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDealsByCategoryClass(String className);

        /// <summary>
        /// Gets the categories by class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>List&lt;Category&gt;.</returns>
        [OperationContract]
        List<Category> getCategoriesByClass(String className);

        /// <summary>
        /// Gets the deals by category.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDealsByCategory(Category c);

        /// <summary>
        /// Gets the last deal.
        /// </summary>
        /// <returns>Deal.</returns>
        [OperationContract]
        Deal getLastDeal();

        /// <summary>
        /// Gets the name of the categories by.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>List&lt;Category&gt;.</returns>
        [OperationContract]
        List<Category> getCategoriesByName(String Name);

        /// <summary>
        /// Gets the name of the deal status by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>DealStatus.</returns>
        [OperationContract]
        DealStatus getDealStatusByName(String name);

        /// <summary>
        /// Gets the security by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Security.</returns>
        [OperationContract]
        Security getSecurityByCode(String code);

        /// <summary>
        /// Gets the name of the company by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Company.</returns>
        [OperationContract]
        Company getCompanyByName(String name);

        /// <summary>
        /// Gets the deals by criteria.
        /// </summary>
        /// <param name="desc">The desc.</param>
        /// <param name="company1">The company1.</param>
        /// <param name="status">The status.</param>
        /// <param name="categoryClass">The category class.</param>
        /// <param name="analyst">The analyst.</param>
        /// <returns>List&lt;Deal&gt;.</returns>
        [OperationContract]
        List<Deal> getDealsByCriteria(String desc, int company1 = 0, int status = 0, String categoryClass = "", String analyst = "");

        /// <summary>
        /// Gets the companies.
        /// </summary>
        /// <returns>List&lt;Company&gt;.</returns>
        [OperationContract]
        List<Company> getCompanies();

        /// <summary>
        /// Gets the securities.
        /// </summary>
        /// <returns>List&lt;Security&gt;.</returns>
        [OperationContract]
        List<Security> getSecurities();

        /// <summary>
        /// Gets the analysts.
        /// </summary>
        /// <returns>List&lt;Analyst&gt;.</returns>
        [OperationContract]
        List<Analyst> getAnalysts();

        /// <summary>
        /// Gets the security types.
        /// </summary>
        /// <returns>List&lt;SecurityType&gt;.</returns>
        [OperationContract]
        List<SecurityType> getSecurityTypes();

        /// <summary>
        /// Gets the merger arb.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>MergerArb.</returns>
        [OperationContract]
        MergerArb getMergerArb(int id);

        /// <summary>
        /// Updates the merger arb.
        /// </summary>
        /// <param name="mb">The mb.</param>
        [OperationContract]
        void updateMergerArb(MergerArb mb);

        /// <summary>
        /// Adds the merger arb.
        /// </summary>
        /// <param name="mb">The mb.</param>
        [OperationContract]
        void addMergerArb(MergerArb mb);

        /// <summary>
        /// Gets the merger arb by deal identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>MergerArb.</returns>
        [OperationContract]
        MergerArb getMergerArbByDealId(int id);

        /// <summary>
        /// Gets the event types.
        /// </summary>
        /// <returns>List&lt;EventType&gt;.</returns>
        [OperationContract]
        List<EventType> getEventTypes();

        /// <summary>
        /// Gets the currencies.
        /// </summary>
        /// <returns>List&lt;Currency&gt;.</returns>
        [OperationContract]
        List<Currency> getCurrencies();

        /// <summary>
        /// Gets the deal statuses.
        /// </summary>
        /// <returns>List&lt;DealStatus&gt;.</returns>
        [OperationContract]
        List<DealStatus> getDealStatuses();

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>List&lt;Category&gt;.</returns>
        [OperationContract]
        List<Category> getCategories();

        /// <summary>
        /// Gets the category classes.
        /// </summary>
        /// <returns>List&lt;Category&gt;.</returns>
        [OperationContract]
        List<Category> getCategoryClasses();

        /// <summary>
        /// Gets the merger arb new by deal identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List&lt;MergerArbNew&gt;.</returns>
        [OperationContract]
        List<MergerArbNew> getMergerArbNewByDealId(int id);

        /// <summary>
        /// Adds the merger arb new.
        /// </summary>
        /// <param name="mb">The mb.</param>
        [OperationContract]
        void addMergerArbNew(MergerArbNew mb);

        /// <summary>
        /// Updates the merger arb new.
        /// </summary>
        /// <param name="mb">The mb.</param>
        [OperationContract]
        void updateMergerArbNew(MergerArbNew mb);

        /// <summary>
        /// Gets the security group by security1.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <returns>SecurityGroup.</returns>
        [OperationContract]
        SecurityGroup getSecurityGroupBySecurity1(int sid);

        /// <summary>
        /// Gets the merger arb new by value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>List&lt;MergerArbNew&gt;.</returns>
        [OperationContract]
        List<MergerArbNew> getMergerArbNewByValue(String value);

        [OperationContract]
        void removeMergerArbNewByDealID(int id);
        //    [OperationContract]
    //    CompositeType GetDataUsingDataContract(CompositeType composite);

    //    // TODO: Add your service operations here
    }


    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
