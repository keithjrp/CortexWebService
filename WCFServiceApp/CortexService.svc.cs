using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq.Expressions;
//using CortexWebService;

namespace CortexWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, 
    // svc and config file together.
    public class CortexWCFServices : CortexWCFService
    {
        /// <summary>
        /// passed Unit Test, returns partial clone of Deal object by id, null if not found in DB
        /// </summary>
        /// <param name="DealId"></param>
        /// <returns></returns>
        public Deal getDeal(int DealId)
        {
            Deal d = new Deal();
            Deal dealCopy = new Deal();
            try
            {
                var crtx = new CortexEntities();
                d = crtx.Deals.Where(x => x.DealID == DealId).FirstOrDefault<Deal>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal " + DealId + ".\n" + e.StackTrace);
            }
            if (d!= null)
            {
                dealCopy = CortexClone.clone(d); 
 
            }
            return dealCopy;

        }
        
        /// <summary>
        ///  Passed Test Client check, returns complete list of Deal objects in the database
        /// </summary>
        /// <returns></returns>
        public List<Deal> getDeals()
        {
            List<Deal> dealList = new List<Deal>(), listCopy = new List<Deal>();
            try
            {
                var crtx = new CortexEntities();
                dealList = crtx.Deals.ToList<Deal>();

                foreach (Deal d in dealList)
                {
                    listCopy.Add(CortexClone.clone(d));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deals.\n" + e.StackTrace);
            }

            return listCopy;

        }

        /// <summary>
        /// Passed Test Client check, returns partial clone of Deal object by desription, null if not found in DB 
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        public List<Deal> getDealsByDescription(String desc)
        {
            IQueryable<Deal> d = null;
            List<MergerArbNew> mList = getMergerArbNewByValue(desc);
            try
            {
                var crtx = new CortexEntities();
                Security s = getSecurityByCode(desc);
                SecurityGroup sg = getSecurityGroupBySecurity1(s.SecurityID);
                d = crtx.Deals.Where(x => x.Description.Contains(desc) 
                    || x.Recommendation.Contains(desc)
                    || x.ValuationMethodology.Contains(desc)
                    || x.InvestmentThesis.Contains(desc)
                    || x.KeyRisks.Contains(desc)
                    || x.TargetPriceValuation.Contains(desc)
                    || x.DownsidePriceValuation.Contains(desc)
                    || x.Background.Contains(desc)
                    || x.Catalyst.Contains(desc)
                    || x.Comps.Contains(desc)
                    || x.CurrentValuation.Contains(desc)
                    || x.SecurityGroupID == sg.SecurityGroupID);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal " + desc + ".\n" + e.StackTrace);
            }

            List<Deal> dealArray = new List<Deal>();
            List<Deal> mbdealArray = new List<Deal>();
            List<Deal> mbdealArrayNoDupes = new List<Deal>();
            Deal temp = new Deal();
            Boolean dealFound = false;
            foreach (Deal dd in d)
            {
                dealArray.Add(CortexClone.clone(dd));
            }
            foreach (MergerArbNew man in mList)
            {
                temp = CortexClone.clone(getDeal((int)man.DealId));
                foreach(Deal de in dealArray)
                {
                    if (de.DealID == temp.DealID)
                        dealFound = true;
                }
                    
                if(!dealFound) dealArray.Add(CortexClone.clone(temp));
            }
            return dealArray;
        }

        /// <summary>
        /// return Deal object of matching Event Date on any of the 4 Events associated with
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Deal getDealByDate(DateTime dt)
        {
            Deal d = new Deal();
            Deal dealCopy = new Deal();

            try
            {
                var crtx = new CortexEntities();

                d = crtx.Deals.Where(x =>
                    x.Event.EventDate == dt ||
                    x.Event1.EventDate == dt ||
                    x.Event2.EventDate == dt ||
                    x.Event3.EventDate == dt).FirstOrDefault<Deal>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal " + dt.ToShortDateString() + ".\n" + e.StackTrace);
            }

            if(d != null)
            {
                dealCopy = CortexClone.clone(d);   
            }

            return dealCopy;

        }

        /// <summary>
        /// passed Unit Test, adds Deal to Database
        /// </summary>
        /// <param name="d"></param>
        public void addDeal(Deal d)
        {
            var crtx = new CortexEntities();

            crtx.Deals.Add(d);
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, removes Deal from Database 
        /// </summary>
        /// <param name="d"></param>
        public void removeDeal(Deal d)
        {
            removeDealById(d.DealID);
        }

        /// <summary>
        /// passed Unit Test, removes Deal from Database 
        /// </summary>
        /// <param name="DealId"></param>
        public void removeDealById(int DealId)
        {
            var crtx = new CortexEntities();
            var deal = (from dd in crtx.Deals
                        where dd.DealID== DealId
                        select dd).FirstOrDefault<Deal>();
            crtx.Deals.Remove(deal);
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, removes Deal from Database 
        /// </summary>
        /// <param name="desc"></param>
        public void removeDealByDescription(String desc)
        {
            var crtx = new CortexEntities();
            var deal = (from dd in crtx.Deals
                        where dd.Description == desc
                        select dd).FirstOrDefault<Deal>();
            crtx.Deals.Remove(deal);
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, update Deal to Database 
        /// </summary>
        /// <param name="d"></param>
        public void updateDeal(Deal d)
        {
            var crtx = new CortexEntities();

            crtx.Entry(d).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Security with matching id, null if not found in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Security getSecurity(int id)
        {
            Security sec = new Security(), secCopy = new Security(); 

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                sec = crtx.Securities.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Security " + id + ".\n" + e.StackTrace);
            }

            if(sec != null)
            {
                secCopy = CortexClone.clone(sec); 
            }

            return secCopy;
        }

        /// <summary>
        /// passed Unit Test, add a Security to database
        /// </summary>
        /// <param name="sec"></param>
        public void addSecurity(Security sec)
        {
            var crtx = new CortexEntities();
            crtx.Securities.Add(sec);
            //crtx.Entry(sec).State = EntityState.Added;
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, updates Security to database, must provide SecurityTypeId as raw int value
        /// </summary>
        /// <param name="sec"></param>
        public void updateSecurity(Security sec)
        {
            var crtx = new CortexEntities();
            crtx.Entry(sec).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check,remove Security record from database
        /// </summary>
        /// <param name="id"></param>
        public void removeSecurity(int id)
        {
            var crtx = new CortexEntities();
            var ss = (from s in crtx.Securities
                        where s.SecurityID == id
                        select s).FirstOrDefault<Security>();
            crtx.Securities.Remove(ss);
            crtx.SaveChanges();
        }

        /// <summary>
        /// passed Unit Test, returns partial clone of SecurityGroup, null if not found in DB
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public SecurityGroup getSecurityGroup(int id)
        {
            SecurityGroup sec = new SecurityGroup(), secCopy = new SecurityGroup();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                sec = crtx.SecurityGroups.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching SecurityGroup " + id + ".\n" + e.StackTrace);
            }

            if (sec != null)
            {
                secCopy = CortexClone.clone(sec); 
            }

            return secCopy;
        }

        /// <summary>
        /// passed Unit Test, returns partial clone of SecurityType, null if not found in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SecurityType getSecurityType(int id)
        {
            SecurityType sec = new SecurityType(), secCopy = new SecurityType();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                sec = crtx.SecurityTypes.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching SecurityType " + id + ".\n" + e.StackTrace);
            }

            if (sec != null)
            {
                secCopy = CortexClone.clone(sec);
            }

            return secCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Company with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company getCompany(int id)
        {
            Company c = new Company(), compCopy = new Company();
            try
            {
                var crtx = new CortexEntities();

                c = crtx.Companies.Find(id);
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Error fetching Company " + id + ".\n" + e.StackTrace);

            }
            if (c != null)
            {
                compCopy = CortexClone.clone(c);

            }

            return compCopy;
        }

        /// <summary>
        /// passed Unit Test, adds Company to database
        /// </summary>
        /// <param name="sec"></param>
        public void addCompany(Company sec)
        {
            var crtx = new CortexEntities();
            crtx.Companies.Add(sec);
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, update Company to database
        /// </summary>
        /// <param name="sec"></param>
        public void updateCompany(Company sec)
        {
            var crtx = new CortexEntities();
            crtx.Entry(sec).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, removes Company from database
        /// </summary>
        /// <param name="id"></param>
        public void removeCompany(int id)
        {
            var crtx = new CortexEntities();
            var comp = (from cc in crtx.Companies
                        where cc.CompanyID == id
                        select cc).FirstOrDefault<Company>();
            crtx.Companies.Remove(comp);
            crtx.SaveChanges();
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a CompanyAssociation with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyAssociation getCompanyAssociation(int id)
        {
            CompanyAssociation c = new CompanyAssociation(), compCopy = new CompanyAssociation();
            try
            {
                var crtx = new CortexEntities();

                c = crtx.CompanyAssociations.Find(id);
            }
            catch (Exception e)
            {

                Console.WriteLine("Error fetching CompanyAssociation " + id + ".\n" + e.StackTrace);

            }
            if (c != null)
            {
                compCopy = CortexClone.clone(c);

            }

            return compCopy;
        }

        /// <summary>
        ///  Passed Test Client check,removes CompanyAssociation from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void removeCompanyAssociation(int id)
        {
            var crtx = new CortexEntities();
            var comp = (from cc in crtx.CompanyAssociations
                        where cc.CompanyAssociationID == id
                        select cc).FirstOrDefault<CompanyAssociation>();
            crtx.CompanyAssociations.Remove(comp);
            crtx.SaveChanges();
        }

        /// <summary>
        ///  Passed Test Client check,updates CompanyAssociation to database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void updateCompanyAssociation(CompanyAssociation ca)
        {
            var crtx = new CortexEntities();
            crtx.Entry(ca).State = EntityState.Modified;
            crtx.SaveChanges();
        }

        /// <summary>
        ///  Passed Test Client check,adds CompanyAssociation to database
        /// </summary>
        /// <param name="ca"></param>
        public void addCompanyAssociation(CompanyAssociation ca)
        {
            var crtx = new CortexEntities();
            crtx.CompanyAssociations.Add(ca);
            crtx.SaveChanges();
        }

        /// <summary>
        ///  Passed Test Client check,return a partial copy of a Document with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Document getDocument(int id)
        {
            Document doc = new Document(), docCopy = new Document();
            try
            {
                var crtx = new CortexEntities();
                doc = crtx.Documents.Find(id);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Document " + id + ".\n" + e.StackTrace);
            }

            if (doc!=null)
            {
                docCopy = CortexClone.clone(doc); 
            }

            return docCopy;

        }

        /// <summary>
        ///  Passed Test Client check, return a partial copy of a Document with matching Name, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Document getDocumentByName(String name)
        {
            Document doc = new Document(), docCopy = new Document();
            try
            {
                var crtx = new CortexEntities();
                doc = crtx.Documents.Where(x => x.Name == name).FirstOrDefault<Document>();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Document " + name + ".\n" + e.StackTrace);
            }

            if (doc != null)
            {
                docCopy = CortexClone.clone(doc);
            }

            return docCopy;

        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a DocumentGroup with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DocumentGroup getDocumentGroup(int id)
        {
            DocumentGroup doc = new DocumentGroup(), docCopy = new DocumentGroup();
            try
            {
                var crtx = new CortexEntities();
                doc = crtx.DocumentGroups.Find(id);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching DocumentGroup " + id + ".\n" + e.StackTrace);
            }

            if (doc != null)
            {
                docCopy = CortexClone.clone(doc); 
            }

            return docCopy;

        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Currency with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Currency getCurrency(int id)
        {
            Currency curr = new Currency(), currCopy = new Currency();
            try
            {
                var crtx = new CortexEntities();
                curr = crtx.Currencies.Find(id);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Currency " + id + ".\n" + e.StackTrace);
            }

            if (curr != null)
            {
                currCopy = CortexClone.clone(curr);
            }

            return currCopy;
        }

        /// <summary>
        ///  Passed Test Client check, retrieves Currency object by Name/Symbol or 3 character Code
        /// </summary>
        /// <param name="codename"></param>
        /// <returns></returns>
        public Currency getCurrencyByCodeOrName(String codename)
        {
            Currency curr = new Currency(), currCopy = new Currency();
            try
            {
                var crtx = new CortexEntities();
                curr = crtx.Currencies.Where(
                    x => x.CurrencyCode == codename || x.CurrencyName == codename).FirstOrDefault<Currency>();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Currency " + codename + ".\n" + e.StackTrace);
            }

            if (curr != null)
            {
                currCopy = CortexClone.clone(curr);
            }

            return currCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Event with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Event getEvent(int id)
        {
            Event e = new Event(), eCopy =  new Event();
            try
            {
                var crtx = new CortexEntities();
                e = crtx.Events.Find(id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching Event " + id + ".\n" + ex.StackTrace);
            }

            if (e != null)
            {
                eCopy = CortexClone.clone(e); 
            }

            return eCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a EventType with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EventType getEventType(int id)
        {
            EventType e = new EventType(), eCopy = new EventType();
            try
            {
                var crtx = new CortexEntities();
                e = crtx.EventTypes.Find(id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching EventType " + id + ".\n" + ex.StackTrace);
            }

            if (e != null)
            {
                eCopy = CortexClone.clone(e);
            }

            return eCopy;
        }

        /// <summary>
        ///  Passed Test Client check,retrieve last Company  inserted to the database
        /// </summary>
        /// <returns></returns>
        public Company getLastCompany()
        {
            Company comp = new Company(), compCopy = new Company();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                comp = crtx.Companies.OrderByDescending(p => p.CompanyID).FirstOrDefault<Company>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Last Company.\n" + e.StackTrace);
            }

            if (comp != null)
            {
                compCopy = CortexClone.clone(comp);
            }
            return compCopy;
        }

        /// <summary>
        ///  Passed Test Client check,retrieve last CompanyAssociation inserted to the database
        /// </summary>
        /// <returns></returns>
        public CompanyAssociation getLastCompanyAssociation()
        {
            CompanyAssociation ca = new CompanyAssociation(), caCopy = new CompanyAssociation();

            try
            {
                var crtx = new CortexEntities();
                ca = crtx.CompanyAssociations.OrderByDescending(
                    c => c.CompanyAssociationID).FirstOrDefault<CompanyAssociation>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Last Company Association.\n" + e.StackTrace);
            }

            if (ca != null)
            {
                caCopy = CortexClone.clone(ca);
            }
            return caCopy;

        }

        /// <summary>
        ///  Passed Test Client check, retrieve last Security inserted to the database
        /// </summary>
        /// <returns></returns>
        public Security getLastSecurity()
        {
            Security sec = new Security(), secCopy = new Security();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                sec = crtx.Securities.OrderByDescending(p => p.SecurityID).FirstOrDefault<Security>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Last Security.\n" + e.StackTrace);
            }

            if (sec != null)
            {
                secCopy = CortexClone.clone(sec);
            }
            return secCopy;
        }

        /// <summary>
        ///  Passed Test Client check, retrieve last Security group inserted to the database
        /// </summary>
        /// <returns></returns>
        public SecurityGroup getLastSecurityGroup()
        {
            SecurityGroup sec = new SecurityGroup(), secCopy = new SecurityGroup();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                sec = crtx.SecurityGroups.OrderByDescending(p => p.SecurityGroupID).FirstOrDefault<SecurityGroup>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Last SecurityGroup.\n" + e.StackTrace);
            }

            if (sec != null)
            {
                secCopy = CortexClone.clone(sec);
            }
            return secCopy;

        }

        /// <summary>
        ///  Passed Test Client check, add Security group to database
        /// </summary>
        /// <param name="newSG"></param>
        public void addSecurityGroup(SecurityGroup newSG)
        {
            var crtx = new CortexEntities();
            crtx.SecurityGroups.Add(newSG);
            //crtx.Entry(sec).State = EntityState.Added;
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check, add Document group to database
        /// </summary>
        /// <param name="newDG"></param>
        public void addDocumentGroup(DocumentGroup newDG)
        {
            var crtx = new CortexEntities();
            crtx.DocumentGroups.Add(newDG);
            //crtx.Entry(sec).State = EntityState.Added;
            crtx.SaveChanges();

        }


        /// <summary>
        ///  Passed Test Client check, retrieve last Security inserted to the database
        /// </summary>
        /// <returns></returns>
        public DocumentGroup getLastDocumentGroup()
        {
            DocumentGroup sec = new DocumentGroup(), secCopy = new DocumentGroup();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                sec = crtx.DocumentGroups.OrderByDescending(p => p.DocumentGroupID).FirstOrDefault<DocumentGroup>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Last SecurityGroup.\n" + e.StackTrace);
            }

            if (sec != null)
            {
                secCopy = CortexClone.clone(sec);
            }
            return secCopy;

        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Price with matching id, if not, null
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public Price getPrice(int pid)
        {
            Price p = new Price(), pCopy = new Price();

            try
            {
                var crtx = new CortexEntities();
                //sec = crtx.Securities.OrderByDescending(p => p.SecurityID).FirstOrDefault<Security>();

                p = crtx.Prices.OrderByDescending(x => x.PriceDateTime).Where(
                    x => x.SecurityID == pid).FirstOrDefault<Price>();
                //p = crtx.Prices.Find(pid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Price.\n" + e.StackTrace);
            }

            if(p!=null)
            {
                pCopy = CortexClone.clone(p);
            }

            return pCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a StatisticType with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StatisticType getStatisticType(int id)
        {
            StatisticType s = new StatisticType(), sCopy = new StatisticType();

            try
            {
                var crtx = new CortexEntities();
                s = crtx.StatisticTypes.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching StatisticType.\n" + e.StackTrace);
            }


            if(s != null)
            {
                sCopy = CortexClone.clone(s);
            }
            return sCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a AnnualCompanyStatistic with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AnnualCompanyStatistic getAnnualCompanyStatistic(int id)
        {
            AnnualCompanyStatistic s = new AnnualCompanyStatistic(), sCopy = new AnnualCompanyStatistic();

            try
            {
                var crtx = new CortexEntities();
                s = crtx.AnnualCompanyStatistics.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching AnnualCompanyStatistic.\n" + e.StackTrace);
            }


            if (s != null)
            {
                sCopy = CortexClone.clone(s);
            }
            return sCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a DealType with matching id, if not, null
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DealType getDealType(int pid)
        {
            DealType d = new DealType(), dCopy = new DealType();

            try
            {
                var crtx = new CortexEntities();
                d = crtx.DealTypes.Find(pid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Price.\n" + e.StackTrace);
            }

            if (d != null)
            {
                dCopy = CortexClone.clone(d);
            }

            return dCopy;
        }

        /// <summary>
        /// passed Unit Test, adds Currency to Database
        /// </summary>
        /// <param name="c"></param>
        public void addCurrency(Currency c)
        {
            var crtx = new CortexEntities();

            crtx.Currencies.Add(c);
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, adds Event to Database
        /// </summary>
        /// <param name="e"></param>
        public void addEvent(Event e)
        {
            var crtx = new CortexEntities();

            crtx.Events.Add(e);
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, adds Event Type to Database
        /// </summary>
        /// <param name="e"></param>
        public void addEventType(EventType e)
        {
            var crtx = new CortexEntities();

            crtx.EventTypes.Add(e);
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, adds Document to Database
        /// </summary>
        /// <param name="d"></param>
        public void addDocument(Document d)
        {
            var crtx = new CortexEntities();

            crtx.Documents.Add(d);
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check, adds Price Record to Database
        /// </summary>
        /// <param name="p"></param>
        public void addPrice(Price p)
        {
            var crtx = new CortexEntities();

            crtx.Prices.Add(p);
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check, adds AnnualCompanyStatistic to Database
        /// </summary>
        /// <param name="acs"></param>
        public void addAnnualCompanyStatistic(AnnualCompanyStatistic acs)
        {
            var crtx = new CortexEntities();

            crtx.AnnualCompanyStatistics.Add(acs);
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check, adds StatisticType to Database
        /// </summary>
        /// <param name="st"></param>
        public void addStatisticType(StatisticType st)
        {
            var crtx = new CortexEntities();

            crtx.StatisticTypes.Add(st);
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check, adds Deal Type to Database
        /// </summary>
        /// <param name="dt"></param>
        public void addDealType(DealType dt)
        {
            var crtx = new CortexEntities();

            crtx.DealTypes.Add(dt);
            crtx.SaveChanges();

        }
        
        /// <summary>
        ///  Passed Test Client check, adds Security Type to Database
        /// </summary>
        /// <param name="st"></param>
        public void addSecurityType(SecurityType st)
        {
            var crtx = new CortexEntities();

            crtx.SecurityTypes.Add(st);
            crtx.SaveChanges();

        }

        public string GetCurrentDate()
        {
            return DateTime.Today.ToString();
        }

        /// <summary>
        ///  Passed Test Client check, updates Document Group to database, must provide Document ID as raw int value
        /// </summary>
        /// <param name="dg"></param>
        public void updateDocumentGroup(DocumentGroup dg)
        {
            var crtx = new CortexEntities();
            crtx.Entry(dg).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check, updates Security Group to database, must provide Security ID as raw int value
        /// </summary>
        /// <param name="sg"></param>
        public void updateSecurityGroup(SecurityGroup sg)
        {
            var crtx = new CortexEntities();
            crtx.Entry(sg).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check, updates Document  to database, must provide Document ID as raw int value
        /// </summary>
        /// <param name="d"></param>
        public void updateDocument(Document d)
        {
            var crtx = new CortexEntities();
            crtx.Entry(d).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        /// <summary>
        ///  Passed Test Client check, retrieve last Document inserted to the database
        /// </summary>
        /// <returns></returns>
        public Document getLastDocument()
        {
            Document doc = new Document(), docCopy = new Document();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                doc = crtx.Documents.OrderByDescending(p => p.DocumentID).FirstOrDefault<Document>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Last Security.\n" + e.StackTrace);
            }

            if (doc != null)
            {
                docCopy = CortexClone.clone(doc);
            }
            return docCopy;

        }

        /// <summary>
        ///  Passed Test Client check, returns partial clone of Deal object by Company ID, null if not found in DB 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<Deal> getDealByCompany(Company c)
        {
            IQueryable<Deal> d = null;

            try
            {
                var crtx = new CortexEntities();

                d = crtx.Deals.Where(
                    x => x.CompanyID1 == c.CompanyID);//
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal " + c + ".\n" + e.StackTrace);
            }
            List<Deal> dealArray = new List<Deal>();
            foreach (Deal dd in d)
            {
                dealArray.Add(CortexClone.clone(dd));
            }        

            return dealArray;

        }

        /// <summary>
        /// Passed Test Client check, returns partial list of Deal object where Expiration Date is greater than today
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<Deal> getDealList()
        {
            IQueryable<Deal> d = null;

            try
            {
                var crtx = new CortexEntities();

                d = crtx.Deals.OrderByDescending(x => x.DealID).Where(t => t.ExpirationDate > DateTime.Now);//
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal list \n" + e.StackTrace);
            }
            List<Deal> dealArray = new List<Deal>();
            foreach(Deal dd in d)
            {
                dealArray.Add(CortexClone.clone(dd));
            }

            return dealArray;

        }

        /// <summary>
        ///  Passed Test Client check, retrieves partial copy of Analyst 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Analyst getAnalyst(int id)
        {
            Analyst a = new Analyst();
            Analyst aCopy = new Analyst();
            try
            {
                var crtx = new CortexEntities();
                a = crtx.Analysts.Find(id);

                if(a != null)
                {
                    aCopy = CortexClone.clone(a);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Analyst " + a.Login + ".\n" + e.StackTrace);
            }

            return aCopy;
        }

        /// <summary>
        ///  Passed Test Client check, retrieves partial copy of Analyst by login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Analyst getAnalystByName(String login)
        {
            Analyst a = new Analyst();
            Analyst aCopy = new Analyst();

            try
            {
                var crtx = new CortexEntities();

                a = crtx.Analysts.Where(x => x.Login == login).FirstOrDefault<Analyst>();

                if (a != null)
                {
                    aCopy = CortexClone.clone(a);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal " + login + ".\n" + e.StackTrace);
            }

            return aCopy;

        }

        /// <summary>
        ///  Passed Test Client check, retrieves partial copy of Deal Status 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DealStatus getDealStatus(int id)
        {
            DealStatus d = new DealStatus();
            DealStatus DealStatusCopy = new DealStatus();
            try
            {
                var crtx = new CortexEntities();
                d = crtx.DealStatuses.Where(x => x.DealStatusID == id).FirstOrDefault<DealStatus>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching DealStatus " + id + ".\n" + e.StackTrace);
            }
            if (d != null)
            {
                DealStatusCopy = CortexClone.clone(d);

            }
            return DealStatusCopy;
            
        }

        /// <summary>
        ///  Passed Test Client check, retrieves partial copy of Deal Strategy 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category getCategory(int id)
        {
            Category c = new Category();
            Category CategoryCopy = new Category();
            try
            {
                var crtx = new CortexEntities();
                c = crtx.Categories.Where(x => x.CategoryID == id).FirstOrDefault<Category>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Category " + id + ".\n" + e.StackTrace);
            }
            if (c != null)
            {
                CategoryCopy = CortexClone.clone(c);

            }
            return CategoryCopy;
        }

        /// <summary>
        ///  Passed Test Client check, retrieves partial copy of Deal/Analyst mapping
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MapDealAnalyst> getDealTeam(int id)
        {
            IQueryable<MapDealAnalyst> m = null;
            List<MapDealAnalyst> mCopy = new List<MapDealAnalyst>();

            try
            {
                var crtx = new CortexEntities();
                m = crtx.MapDealAnalysts.Where(
                    x => x.DealID == id || x.AnalystID == id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching MapDealAnalyst " + id + ".\n" + e.StackTrace);
            }

            foreach(MapDealAnalyst mm in m)
            {
                mCopy.Add(CortexClone.clone(mm));
            }
            return mCopy;
        }

        /// <summary>
        ///  Passed Test Client check, adds Deal/Analyst mapping to database
        /// </summary>
        /// <param name="mda"></param>
        public void addMapDealAnalyst(MapDealAnalyst mda)
        {
            var crtx = new CortexEntities();

            crtx.MapDealAnalysts.Add(mda);
            crtx.SaveChanges();
        }

        /// <summary>
        ///  Passed Test Client check, updates Deal/Analyst mapping to database
        /// </summary>
        /// <param name="mda"></param>
        public void updateMapDealAnalyst(MapDealAnalyst mda)
        {
            var crtx = new CortexEntities();
            crtx.Entry(mda).State = EntityState.Modified;
            crtx.SaveChanges();
        }

        /// <summary>
        ///  Passed Test Client check, retrieves partial copy of Deal/Analyst mapping
        /// </summary>
        /// <param name="DealId"></param>
        /// <param name="AnalystId"></param>
        /// <returns></returns>
        public MapDealAnalyst getMapDealAnalyst(int DealId, int AnalystId)
        {
            MapDealAnalyst m = new MapDealAnalyst();
            MapDealAnalyst mCopy = new MapDealAnalyst();

            try
            {
                var crtx = new CortexEntities();
                m = crtx.MapDealAnalysts.Where(
                    x => x.AnalystID == AnalystId && x.DealID == DealId).FirstOrDefault<MapDealAnalyst>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching MapDealAnalyst.\n" + e.StackTrace);
            }

            if(m !=  null)
            {
                mCopy = CortexClone.clone(m);
            }

            return mCopy;
        }

        /// <summary>
        ///  Passed Test Client check, retrieves a list of Deals containing the Analyst on the Deal Team
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public List<Deal> getDealByAnalyst(Analyst m)
        {
            IQueryable<MapDealAnalyst> mda = null;

            try
            {
                var crtx = new CortexEntities();

                mda = crtx.MapDealAnalysts.Where(x => x.AnalystID == m.AnalystID);//
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal " + m + ".\n" + e.StackTrace);
            }
            List<Deal> dealArray = new List<Deal>();
            foreach (MapDealAnalyst mm in mda)
            {
                dealArray.Add(CortexClone.clone(getDeal((int)mm.DealID)));
            }

            return dealArray;

        }

        /// <summary>
        ///  Passed Test Client check, retrieves a list of Events with the same Deal Id
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public List<Event> getEventsByDeal(int d)
        {
            IQueryable<Event> e = null;
            try
            {
                var crtx = new CortexEntities();
                e = crtx.Events.Where(x => x.DealID == d);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching Event for Deal " + d + ".\n" + ex.StackTrace);
            }

            List<Event> eCopy = new List<Event>();
            foreach(Event ee in e)
            {
                eCopy.Add(CortexClone.clone(ee));
            }

            return eCopy;
        }

        /// <summary>
        ///  Passed Test Client check, retrieves a list of Documents with the same Deal Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Document> getDocumentsByDeal(int id)
        {
            IQueryable<Document> d = null;

            try
            {
                var crtx = new CortexEntities();
                d = crtx.Documents.Where(x => x.DealId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching Document for Deal " + id + ".\n" + ex.StackTrace);
            }

            List<Document> dCopy = new List<Document>();
            foreach(Document dd in d)
            {
                dCopy.Add(CortexClone.clone(dd));
            }
            return dCopy;
        }

        /// <summary>
        ///  Passed Test Client check, retrieve last Event inserted to the database
        ///  these getLast.. methods is because some tables didn't have an identity field setup
        ///  with identity seed and auto increment.  Their add methods will fail if the id is not 
        ///  given an explicit value.  The getLast methods retrieves the last id value inserted and 
        ///  lets the developer calculate the next id value to insert.  Workaround of bad initial SQL table setup.
        ///  Subsequent tables/objects will not have this problem.
        /// </summary>
        /// <returns></returns>
        public Event getLastEvent()
        {
            Event ev = new Event(), evCopy = new Event();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                ev = crtx.Events.OrderByDescending(p => p.EventID).FirstOrDefault<Event>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Last Event.\n" + e.StackTrace);
            }

            if (ev != null)
            {
                evCopy = CortexClone.clone(ev);
            }
            return evCopy;
        }

        /// <summary>
        ///  Passed Test Client check, removes Event from database
        /// </summary>
        /// <param name="id"></param>
        public void removeEvent(int id)
        {
            var crtx = new CortexEntities();
            var ev = (from cc in crtx.Events
                        where cc.EventID == id
                        select cc).FirstOrDefault<Event>();
            crtx.Events.Remove(ev);
            crtx.SaveChanges();
        }

        /// <summary>
        ///  Passed Test Client check, removes Document from database
        /// </summary>
        /// <param name="id"></param>
        public void removeDocument(int id)
        {
            var crtx = new CortexEntities();
            var doc = (from cc in crtx.Documents
                        where cc.DocumentID == id
                        select cc).FirstOrDefault<Document>();
            crtx.Documents.Remove(doc);
            crtx.SaveChanges();
        }

        /// <summary>
        ///  Passed Test Client check, removes Deal/Analyst mapping from database, 
        ///  essentially removes an Analyst from a Deal team.
        /// </summary>
        /// <param name="id"></param>
        public void removeMapDealAnalyst(int id)
        {
            var crtx = new CortexEntities();
            var mda = (from cc in crtx.MapDealAnalysts
                        where cc.MapDealAnalystID == id
                        select cc).FirstOrDefault<MapDealAnalyst>();
            crtx.MapDealAnalysts.Remove(mda);
            crtx.SaveChanges();
        }

        /// <summary>
        ///  Passed Test Client check, records Deal insertion to database
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="d"></param>
        public void AuditTrailAdd(ApplicationUser usr, Deal d)
        {
            usr.IsDeleted = false;
            usr.DomainCredential = usr.DomainCredential == null ? "halcyon.local": usr.DomainCredential;
            usr.CreatedDateTime = DateTime.Now;
            usr.EditedDateTime = DateTime.Now;
            usr.LastAccessDateTime = DateTime.Now;
            usr.Actions = "[Deal ID: " + d.DealID + " Added to DB]";

            var crtx = new CortexEntities();
            crtx.ApplicationUsers.Add(usr);
            crtx.SaveChanges();
        }

        /// <summary>
        /// Passed Test Client check, records Deal updates to database
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="d"></param>
        public void AuditTrailUpdate(ApplicationUser usr, Deal d)
        {
            usr.IsDeleted = false;
            usr.DomainCredential = usr.DomainCredential == null ? "halcyon.local" : usr.DomainCredential;
            usr.CreatedDateTime = DateTime.Now;
            usr.EditedDateTime = DateTime.Now;
            usr.LastAccessDateTime = DateTime.Now;
            usr.Actions = "[Deal ID: " + d.DealID + " Updated to DB]" + usr.Actions;

            var crtx = new CortexEntities();
            crtx.ApplicationUsers.Add(usr);
            crtx.SaveChanges();
        }

        /// <summary>
        /// Passed Test Client check, records Deal deletion to database
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="d"></param>
        public void AuditTrailDelete(ApplicationUser usr, Deal d)
        {
            usr.IsDeleted = true;
            usr.DomainCredential = usr.DomainCredential == null ? "halcyon.local" : usr.DomainCredential;
            usr.CreatedDateTime = DateTime.Now;
            usr.EditedDateTime = DateTime.Now;
            usr.LastAccessDateTime = DateTime.Now;
            usr.Actions = "[Deal ID: " + d.DealID + " Removed from DB]";

            var crtx = new CortexEntities();
            crtx.ApplicationUsers.Add(usr);
            crtx.SaveChanges();
        }

        /// <summary>
        /// Passed Test Client check, records user login to Cortex Application
        /// </summary>
        /// <param name="usr"></param>
        public void AuditTrailLogin(ApplicationUser usr)
        {
            usr.IsDeleted = false;
            usr.DomainCredential = usr.DomainCredential == null ? "halcyon.local" : usr.DomainCredential;
            usr.CreatedDateTime = DateTime.Now;
            usr.EditedDateTime = DateTime.Now;
            usr.LastAccessDateTime = DateTime.Now;
            usr.Actions = "[User Logged In]";

            var crtx = new CortexEntities();
            crtx.ApplicationUsers.Add(usr);
            crtx.SaveChanges();
        }

        /// <summary>
        /// Passed Test Client check, records user logout/exit/quit to Cortex Application
        /// </summary>
        /// <param name="usr"></param>
        public void AuditTrailLogout(ApplicationUser usr)
        {
            usr.IsDeleted = false;
            usr.DomainCredential = usr.DomainCredential == null ? "halcyon.local" : usr.DomainCredential;
            usr.CreatedDateTime = DateTime.Now;
            usr.EditedDateTime = DateTime.Now;
            usr.LastAccessDateTime = DateTime.Now;
            usr.Actions = "[User Logged Out]";

            var crtx = new CortexEntities();
            crtx.ApplicationUsers.Add(usr);
            crtx.SaveChanges();
        }

        /// <summary>
        /// Passed Test Client check, records user vselecting and viewing a Deal
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="d"></param>
        public void AuditTrailView(ApplicationUser usr, Deal d)
        {
            usr.IsDeleted = false;
            usr.DomainCredential = usr.DomainCredential == null ? "halcyon.local" : usr.DomainCredential;
            usr.CreatedDateTime = DateTime.Now;
            usr.EditedDateTime = DateTime.Now;
            usr.LastAccessDateTime = DateTime.Now;
            usr.Actions = "[Deal ID: " + d.DealID + " Viewed by User]";

            var crtx = new CortexEntities();
            crtx.ApplicationUsers.Add(usr);
            crtx.SaveChanges();
        }

        /// <summary>
        /// Passed Test Client check, retrieves partial copy of Deal with the matching Status
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public List<Deal> getDealByStatus(DealStatus ds)
        {
            IQueryable<Deal> d = null;

            try
            {
                var crtx = new CortexEntities();

                d = crtx.Deals.Where(x => x.DealStatusID == ds.DealStatusID);//
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal if status" + ds.Code + ".\n" + e.StackTrace);
            }
            List<Deal> dealArray = new List<Deal>();
            foreach (Deal dd in d)
            {
                dealArray.Add(CortexClone.clone(getDeal((int)dd.DealID)));
            }

            return dealArray;

        }

        /// <summary>
        /// Passed Test Client check, retrieves a list of Deals with the matching Strategy/Category
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public List<Deal> getDealsByCategory(Category c)
        {
            IQueryable<Deal> d = null;

            try
            {
                var crtx = new CortexEntities();
                d = crtx.Deals.Where(x => x.CategoryID == c.CategoryID);//
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal of category" + c.Name + ".\n" + e.StackTrace);
            }
            List<Deal> dealArray = new List<Deal>();
            foreach (Deal dd in d)
            {
                dealArray.Add(CortexClone.clone(getDeal((int)dd.DealID)));
            }

            return dealArray;

        }

        /// <summary>
        /// Passed Test Client check, retrieves a list of Strategies/Categories with the matching Class name
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<Category> getCategoriesByClass(String className)
        {
            IQueryable<Category> c = null;

            try
            {
                var crtx = new CortexEntities();
                c = crtx.Categories.Where(x => x.Class == className);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Category of Class" + className + ".\n" + e.StackTrace);
            }

            List<Category> catList = new List<Category>();
            foreach(Category cat in c)
            {
                catList.Add(CortexClone.clone(getCategory((int)cat.CategoryID)));
            }

            return catList;
        }

        /// <summary>
        /// Passed Test Client check, retrieves a list of Deals 
        /// with the matching Strategies/Categories with the same Class name
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public List<Deal> getDealsByCategoryClass(String className)
        {
            List<Deal> dealArray = new List<Deal>();
            try
            {
                var crtx = new CortexEntities();
                List<Category> catList = getCategoriesByClass(className);

                foreach (Category cat in catList)
                {
                    dealArray.AddRange(getDealsByCategory(cat));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal of category" + className + ".\n" + e.StackTrace);
            }

            return dealArray;

        }

        /// <summary>
        ///  Passed Test Client check,retrieve last Company  inserted to the database
        /// </summary>
        /// <returns></returns>
        public Deal getLastDeal()
        {
            Deal comp = new Deal(), compCopy = new Deal();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                comp = crtx.Deals.OrderByDescending(p => p.DealID).FirstOrDefault<Deal>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Last Company.\n" + e.StackTrace);
            }

            if (comp != null)
            {
                compCopy = CortexClone.clone(comp);
            }
            return compCopy;
        }

        /// <summary>
        /// Passed Test Client check, retrieves a list of Strategies/Categories with the matching Class name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Category> getCategoriesByName(String Name)
        {
            IQueryable<Category> c = null;

            try
            {
                var crtx = new CortexEntities();
                c = crtx.Categories.Where(x => x.Name.Contains(Name));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Category of Class" + Name + ".\n" + e.StackTrace);
            }

            List<Category> catList = new List<Category>();
            foreach (Category cat in c)
            {
                catList.Add(CortexClone.clone(getCategory((int)cat.CategoryID)));
            }

            return catList;
        }

        /// <summary>
        ///  Passed Test Client check, retrieves partial copy of Deal Status 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DealStatus getDealStatusByName(String name)
        {
            DealStatus d = new DealStatus();
            DealStatus DealStatusCopy = new DealStatus();
            try
            {
                var crtx = new CortexEntities();
                d = crtx.DealStatuses.Where(x => x.Code == name || x.Name == name).FirstOrDefault<DealStatus>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching DealStatus " + name + ".\n" + e.StackTrace);
            }
            if (d != null)
            {
                DealStatusCopy = CortexClone.clone(d);

            }
            return DealStatusCopy;

        }


        /// <summary>
        /// passed Unit Test, return a partial copy of a Security with matching Code or Name, null if not found in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Security getSecurityByCode(String code)
        {
            Security sec = new Security(), secCopy = new Security();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                sec = crtx.Securities.Where(x => x.Code.Contains(code) || x.Name.Contains(code)).FirstOrDefault<Security>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Security " + code + ".\n" + e.StackTrace);
            }

            if (sec != null)
            {
                secCopy = CortexClone.clone(sec);
            }

            return secCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Company with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company getCompanyByName(String name)
        {
            Company c = new Company(), compCopy = new Company();
            try
            {
                var crtx = new CortexEntities();

                c = crtx.Companies.Where(x => x.Code.Contains(name) || x.Name.Contains(name)).FirstOrDefault<Company>();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error fetching Company " + name + ".\n" + e.StackTrace);

            }
            if (c != null)
            {
                compCopy = CortexClone.clone(c);

            }

            return compCopy;
        }

        /// <summary>
        /// Passed Test Client check, returns partial clone of Deal object by desription, null if not found in DB 
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        public List<Deal> getDealsByCriteria(String desc, int company1 = 0, int status = 0, 
            String categoryClass = "", String analyst = "")
        {
            List<Deal> d1 = null;
            IEnumerable<Deal> d2 = null;

            try
            {
                var crtx = new CortexEntities();
                var predicateAND = PredicateBuilder.True<Deal>();

                d1 = getDealsByDescription(desc);

                if (company1 != 0 || status != 0 || categoryClass != "")
                {
                    if (company1 != 0) predicateAND = predicateAND.And(x => x.CompanyID1 == company1);
                    if (status != 0) predicateAND = predicateAND.And(x => x.DealStatusID == status);
                    if (categoryClass != "") predicateAND = predicateAND.And(x => x.Category.Class == categoryClass);

                    d2 = from dd in crtx.Deals.Where(predicateAND.Compile())
                         select dd;

                    var d = from aa in d1
                            join bb in d2 on aa.DealID equals bb.DealID
                            select aa;
                    d1 = d.ToList<Deal>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal " + desc + ".\n" + e.StackTrace);
            }

            List<Deal> dealArray = filterDealResultsByAnalyst(analyst, d1);

            return dealArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="analyst">Analyst name to filter by</param>
        /// <param name="d">List of Deals from Search Result</param>
        /// <returns></returns>
        private List<Deal> filterDealResultsByAnalyst(String analyst, IEnumerable<Deal> d)
        {
            List<Deal> dealByAnalyst = new List<Deal>();
            List<Deal> dealArray = new List<Deal>();
            try
            {
                if (analyst != "")
                {
                    dealByAnalyst = this.getDealByAnalyst(this.getAnalystByName(analyst));
                }
                foreach (Deal dd in d)
                {
                    if (analyst != "")
                    {
                        foreach (Deal aa in dealByAnalyst)
                        {
                            if (aa.DealID == dd.DealID)
                                dealArray.Add(CortexClone.clone(dd));
                        }
                    }
                    else
                    {
                        dealArray.Add(CortexClone.clone(dd));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return dealArray;
        }

        /// <summary>
        ///  Passed Test Client check, returns complete list of Company objects in the database
        /// </summary>
        /// <returns></returns>
        public List<Company> getCompanies()
        {
            List<Company> CompanyList = new List<Company>(), listCopy = new List<Company>();
            try
            {
                var crtx = new CortexEntities();
                CompanyList = crtx.Companies.OrderBy(x => x.Description).ToList<Company>();

                foreach (Company d in CompanyList)
                {
                    listCopy.Add(CortexClone.clone(d));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Companies.\n" + e.StackTrace);
            }

            return listCopy;

        }

        /// <summary>
        ///  Passed Test Client check, returns complete list of Security objects in the database
        /// </summary>
        /// <returns></returns>
        public List<Security> getSecurities()
        {
            List<Security> SecurityList = new List<Security>(), listCopy = new List<Security>();
            try
            {
                var crtx = new CortexEntities();
                SecurityList = crtx.Securities.ToList<Security>();

                foreach (Security d in SecurityList)
                {
                    listCopy.Add(CortexClone.clone(d));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Securities.\n" + e.StackTrace);
            }

            return listCopy;

        }

        /// <summary>
        ///  Passed Test Client check, returns complete list of Analyst objects in the database
        /// </summary>
        /// <returns></returns>
        public List<Analyst> getAnalysts()
        {
            List<Analyst> AnalystList = new List<Analyst>(), listCopy = new List<Analyst>();
            try
            {
                var crtx = new CortexEntities();
                AnalystList = crtx.Analysts.OrderBy(a => a.Login).ToList<Analyst>();

                foreach (Analyst d in AnalystList)
                {
                    listCopy.Add(CortexClone.clone(d));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Analysts.\n" + e.StackTrace);
            }

            return listCopy;

        }

        /// <summary>
        ///  Passed Test Client check, returns complete list of SecurityType objects in the database
        /// </summary>
        /// <returns></returns>
        public List<SecurityType> getSecurityTypes()
        {
            List<SecurityType> SecurityTypeList = new List<SecurityType>(), listCopy = new List<SecurityType>();
            try
            {
                var crtx = new CortexEntities();
                SecurityTypeList = crtx.SecurityTypes.ToList<SecurityType>();

                foreach (SecurityType d in SecurityTypeList)
                {
                    listCopy.Add(CortexClone.clone(d));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching Securities.\n" + e.StackTrace);
            }

            return listCopy;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MergerArb getMergerArb(int id)
        {
            MergerArb marb = new MergerArb();
            var crtx = new CortexEntities();
               marb = crtx.MergerArbs.Find(id);


               return marb;
        }


        /// <summary>
        /// passed Unit Test, update MergerArb to database
        /// </summary>
        /// <param name="mb"></param>
        public void updateMergerArb(MergerArb mb)
        {
            var crtx = new CortexEntities();
            crtx.Entry(mb).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, adds MergerArb to database
        /// </summary>
        /// <param name="mb"></param>
        public void addMergerArb(MergerArb mb)
        {
            var crtx = new CortexEntities();
            crtx.MergerArbs.Add(mb);
            crtx.SaveChanges();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MergerArb getMergerArbByDealId(int id)
        {
            MergerArb marb = new MergerArb();
            var crtx = new CortexEntities();
            marb = crtx.MergerArbs.Where(m => m.C000_DealId__Required_ == id).FirstOrDefault<MergerArb>();

            return marb;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a EventType with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EventType> getEventTypes()
        {
            List<EventType> e = new List<EventType>(), eCopy = new List<EventType>();
            try
            {
                var crtx = new CortexEntities();
                e = crtx.EventTypes.ToList<EventType>();

                foreach (EventType d in e)
                {
                    eCopy.Add(CortexClone.clone(d));
                } 

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching EventTypes \n" + ex.StackTrace);
            }

            return eCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Currency with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Currency> getCurrencies()
        {
            List<Currency> e = new List<Currency>(), eCopy = new List<Currency>();
            try
            {
                var crtx = new CortexEntities();
                e = crtx.Currencies.ToList<Currency>();

                foreach (Currency d in e)
                {
                    eCopy.Add(CortexClone.clone(d));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching Currencies \n" + ex.StackTrace);
            }

            return eCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a DealStatus with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DealStatus> getDealStatuses()
        {
            List<DealStatus> e = new List<DealStatus>(), eCopy = new List<DealStatus>();
            try
            {
                var crtx = new CortexEntities();
                e = crtx.DealStatuses.ToList<DealStatus>();

                foreach (DealStatus d in e)
                {
                    eCopy.Add(CortexClone.clone(d));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching DealStatuses \n" + ex.StackTrace);
            }

            return eCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Category with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Category> getCategories()
        {
            List<Category> e = new List<Category>(), eCopy = new List<Category>();
            try
            {
                var crtx = new CortexEntities();
                e = crtx.Categories.OrderBy(x => x.Name).ToList<Category>();

                foreach (Category d in e)
                {
                    eCopy.Add(CortexClone.clone(d));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching Categoryes \n" + ex.StackTrace);
            }

            return eCopy;
        }

        /// <summary>
        /// passed Unit Test, return a partial copy of a Category with matching id, if not, null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Category> getCategoryClasses()
        {
            List<Category> e = new List<Category>(), eCopy = new List<Category>();
            List<String> classes = new List<string>();
            try
            {
                var crtx = new CortexEntities();
                e = crtx.Categories.OrderBy(x => x.Class).ToList<Category>();

                foreach (Category d in e)
                {
                    if (eCopy.Count > 0 )
                    {
                        if (!classes.Contains(d.Class))
                        {
                            eCopy.Add(CortexClone.clone(d));
                            classes.Add(d.Class); 
                        }
                    }
                    else
                    {
                        eCopy.Add(CortexClone.clone(d));
                        classes.Add(d.Class);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching Categories \n" + ex.StackTrace);
            }

            return eCopy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MergerArbNew> getMergerArbNewByDealId(int id)
        {
            List<MergerArbNew> marb = new List<MergerArbNew>();
            var crtx = new CortexEntities();
            marb = crtx.MergerArbNews.Where(m => m.DealId == id).ToList<MergerArbNew>();

            return marb;
        }

        /// <summary>
        /// passed Unit Test, adds MergerArb to database
        /// </summary>
        /// <param name="mb"></param>
        public void addMergerArbNew(MergerArbNew mb)
        {
            var crtx = new CortexEntities();
            crtx.MergerArbNews.Add(mb);
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, update MergerArb to database
        /// </summary>
        /// <param name="mb"></param>
        public void updateMergerArbNew(MergerArbNew mb)
        {
            var crtx = new CortexEntities();
            crtx.Entry(mb).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        /// <summary>
        /// passed Unit Test, returns partial clone of SecurityGroup, null if not found in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SecurityGroup getSecurityGroupBySecurity1(int sid)
        {
            SecurityGroup sec = new SecurityGroup(), secCopy = new SecurityGroup();

            try
            {
                var crtx = new CortexEntities();
                //var sec = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();
                sec = crtx.SecurityGroups.Where(x => x.SecurityID1 == sid).FirstOrDefault<SecurityGroup>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching SecurityGroup Security ID" + sid + ".\n" + e.StackTrace);
            }

            if (sec != null)
            {
                secCopy = CortexClone.clone(sec);
            }

            return secCopy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MergerArbNew> getMergerArbNewByValue(String value)
        {
            List<MergerArbNew> marb = new List<MergerArbNew>();
            var crtx = new CortexEntities();
            marb = crtx.MergerArbNews.Where(m => m.Field_Value.Contains(value)).ToList<MergerArbNew>();

            return marb;
        }
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
