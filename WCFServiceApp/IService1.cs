using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace CortexWebService
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface CortexWCFService
    {

        [OperationContract]
        Deal getDeal(int DealId);

        [OperationContract]
        List<Deal> getDeals(int count = 30);

        [OperationContract]
        void addDeal(Deal d);

        [OperationContract]
        void removeDeal(Deal d);

        [OperationContract]
        void updateDeal(Deal d);

        [OperationContract]
        List<Deal> getDealsByDescription(String desc);

        [OperationContract]
        Deal getDealByDate(DateTime dt);

        [OperationContract]
        void removeDealById(int DealId);

        [OperationContract]
        void removeDealByDescription(String desc);

        [OperationContract]
        Security getSecurity(int id);

        [OperationContract]
        void addSecurity(Security sec);

        [OperationContract]
        void updateSecurity(Security sec);

        [OperationContract]
        void removeSecurity(int id);

        [OperationContract]
        Company getCompany(int id);

        [OperationContract]
        void addCompany(Company sec);

        [OperationContract]
        void updateCompany(Company sec);

        [OperationContract]
        void removeCompany(int id);

        [OperationContract]
        Document getDocument(int id);

        [OperationContract]
        Currency getCurrency(int id);

        [OperationContract]
        Event getEvent(int id);

        [OperationContract]
        EventType getEventType(int id);

        [OperationContract]
        DocumentGroup getDocumentGroup(int id);

        [OperationContract]
        SecurityGroup getSecurityGroup(int id);

        [OperationContract]
        SecurityType getSecurityType(int id);

        [OperationContract]
        CompanyAssociation getCompanyAssociation(int id);

        [OperationContract]
        void removeCompanyAssociation(int id);

        [OperationContract]
        void updateCompanyAssociation(CompanyAssociation ca);

        [OperationContract]
        void addCompanyAssociation(CompanyAssociation ca);

        [OperationContract]
        Company getLastCompany();

        [OperationContract]
        CompanyAssociation getLastCompanyAssociation();

        [OperationContract]
        Security getLastSecurity();

        [OperationContract]
        SecurityGroup getLastSecurityGroup();

        [OperationContract]
        void addSecurityGroup(SecurityGroup newSG);

        [OperationContract]
        void addDocumentGroup(DocumentGroup newDG);

        [OperationContract]
        Currency getCurrencyByCodeOrName(String codename);

        [OperationContract]
        DocumentGroup getLastDocumentGroup();

        [OperationContract]
        Price getPrice(int pid);

        [OperationContract]
        StatisticType getStatisticType(int id);

        [OperationContract]
        AnnualCompanyStatistic getAnnualCompanyStatistic(int id);

        [OperationContract]
        DealType getDealType(int pid);

        [OperationContract]
        void addCurrency(Currency c);

        [OperationContract]
        void addDocument(Document d);

        [OperationContract]
        void addEvent(Event e);

        [OperationContract]
        void addEventType(EventType e);

        [OperationContract]
        void addPrice(Price p);

        [OperationContract]
        void addAnnualCompanyStatistic(AnnualCompanyStatistic acs);

        [OperationContract]
        void addStatisticType(StatisticType st);

        [OperationContract]
        void addDealType(DealType dt);

        [OperationContract]
        void addSecurityType(SecurityType st);

        [OperationContract]
        void updateDocumentGroup(DocumentGroup dg);

        [OperationContract]
        void updateSecurityGroup(SecurityGroup sg);

        [OperationContract]
        Document getDocumentByName(String name);

        [OperationContract]
        void updateDocument(Document d);

        [OperationContract]
        Document getLastDocument();

        [OperationContract]
        List<Deal> getDealByCompany(Company c);

        [OperationContract]
        List<Deal> getDealList();

        [OperationContract]
        Analyst getAnalyst(int id);

        [OperationContract]
        Analyst getAnalystByName(String login);

        [OperationContract]
        string GetCurrentDate();

        [OperationContract]
        DealStatus getDealStatus(int id);

        [OperationContract]
        Category getCategory(int id);

        [OperationContract]
        List<MapDealAnalyst> getDealTeam(int id);

        [OperationContract]
        void updateMapDealAnalyst(MapDealAnalyst mda);

        [OperationContract]
        void addMapDealAnalyst(MapDealAnalyst mda);

        [OperationContract]
        MapDealAnalyst getMapDealAnalyst(int DealId, int AnalystId);

        [OperationContract]
        List<Deal> getDealByAnalyst(Analyst m);

        [OperationContract]
        List<Event> getEventsByDeal(int d);

        [OperationContract]
        List<Document> getDocumentsByDeal(int id);

        [OperationContract]
        Event getLastEvent();

        [OperationContract]
        void removeEvent(int id);

        [OperationContract]
        void removeDocument(int id);

        [OperationContract]
        void removeMapDealAnalyst(int id);

        [OperationContract]
        void AuditTrailAdd(ApplicationUser usr, Deal d);

        [OperationContract]
        void AuditTrailUpdate(ApplicationUser usr, Deal d);

        [OperationContract]
        void AuditTrailDelete(ApplicationUser usr, Deal d);

        [OperationContract]
        void AuditTrailLogin(ApplicationUser usr);

        [OperationContract]
        void AuditTrailLogout(ApplicationUser usr);

        [OperationContract]
        void AuditTrailView(ApplicationUser usr, Deal d);

        [OperationContract]
        List<Deal> getDealByStatus(DealStatus ds);

        [OperationContract]
        List<Deal> getDealsByCategoryClass(String className);

        [OperationContract]
        List<Category> getCategoriesByClass(String className);

        [OperationContract]
        List<Deal> getDealsByCategory(Category c);

        [OperationContract]
        Deal getLastDeal();

        [OperationContract]
        List<Category> getCategoriesByName(String Name);

        [OperationContract]
        DealStatus getDealStatusByName(String name);

        [OperationContract]
        Security getSecurityByCode(String code);

        [OperationContract]
        Company getCompanyByName(String name);

        [OperationContract]
        List<Deal> getDealsByCriteria(String desc, int company1 = 0, int status = 0, String categoryClass = "", String analyst = "");

        [OperationContract]
        List<Company> getCompanies();

        [OperationContract]
        List<Security> getSecurities();

        [OperationContract]
        List<Analyst> getAnalysts();

        [OperationContract]
        List<SecurityType> getSecurityTypes();

        [OperationContract]
        MergerArb getMergerArb(int id);

        [OperationContract]
        void updateMergerArb(MergerArb mb);

        [OperationContract]
        void addMergerArb(MergerArb mb);

        [OperationContract]
        MergerArb getMergerArbByDealId(int id);

        [OperationContract]
        List<EventType> getEventTypes();

        [OperationContract]
        List<Currency> getCurrencies();

        [OperationContract]
        List<DealStatus> getDealStatuses();

        [OperationContract]
        List<Category> getCategories();

        [OperationContract]
        List<Category> getCategoryClasses();

        [OperationContract]
        List<MergerArbNew> getMergerArbNewByDealId(int id);

        [OperationContract]
        void addMergerArbNew(MergerArbNew mb);

        [OperationContract]
        void updateMergerArbNew(MergerArbNew mb);

        [OperationContract]
        SecurityGroup getSecurityGroupBySecurity1(int sid);

        [OperationContract]
        List<MergerArbNew> getMergerArbNewByValue(String value);
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
