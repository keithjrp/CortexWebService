using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Entity;

namespace WcfServiceLibraryTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CortexService314 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Deal getDeal(int DealId)
        {
            
            Deal d = new Deal();
            Deal dealCopy = new Deal();
            try
            {
                var crtx = new CortexEntities();
                d = crtx.Deals.Find(DealId);
                //var d = crtx.Deals.Where(x => x.DealID == DealId).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching deal " + DealId + ". " + e.StackTrace);
            }
            dealCopy.DealID = d.DealID;
            dealCopy.Description = d.Description;
            dealCopy.Currency = d.Currency;
            dealCopy.InvestmentThesis = d.InvestmentThesis;
            dealCopy.Company1 = d.Company1;
            dealCopy.Company2 = d.Company2;
            dealCopy.DocumentGroup = d.DocumentGroup;
            dealCopy.Recommendation = d.Recommendation;
            dealCopy.TargetPrice = d.TargetPrice;
            dealCopy.SecurityGroupID = d.SecurityGroupID;
            return dealCopy;
        }

        public Deal getDealByDescription(String desc)
        {
            var crtx = new CortexEntities();

            var d = crtx.Deals.Where(x => x.Description == desc).FirstOrDefault<Deal>();

            return d;

        }

        public Deal getDealByDate(DateTime dt)
        {
            var crtx = new CortexEntities();

            var d = crtx.Deals.Where(x => 
                x.Event.EventDate == dt ||
                x.Event1.EventDate == dt ||
                x.Event2.EventDate == dt ||
                x.Event3.EventDate == dt).FirstOrDefault<Deal>();

            return d;

        }

        public void addDeal(Deal d)
        {
            var crtx = new CortexEntities();

            crtx.Deals.Add(d);
            crtx.SaveChanges();

        }

        public void removeDeal(Deal d)
        {
            var crtx = new CortexEntities();

            crtx.Deals.Remove(d);
            crtx.SaveChanges();

        }

        public void removeDealById(int DealId)
        {
            var crtx = new CortexEntities();
            var deal = (from dd in crtx.Deals
                        where dd.DealID== DealId
                        select dd).FirstOrDefault<Deal>();
            crtx.Deals.Remove(deal);
            crtx.SaveChanges();

        }

        public void removeDealByDescription(String desc)
        {
            var crtx = new CortexEntities();
            var deal = (from dd in crtx.Deals
                        where dd.Description == desc
                        select dd).FirstOrDefault<Deal>();
            crtx.Deals.Remove(deal);
            crtx.SaveChanges();

        }

        public void updateDeal(Deal d)
        {
            var crtx = new CortexEntities();

            //crtx.Entry(d).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        public Security getSecurity(int id)
        {
            var crtx = new CortexEntities();

            var s = crtx.Securities.Where(x => x.SecurityID == id).FirstOrDefault<Security>();

            return s;
        }

        public void addSecurity(Security sec)
        {
            var crtx = new CortexEntities();
            crtx.Securities.Add(sec);
            crtx.SaveChanges();

        }

        public void updateSecurity(Security sec)
        {
            var crtx = new CortexEntities();
            //crtx.Entry(sec).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        public Company getCompany(int id)
        {
            var crtx = new CortexEntities();

            var s = crtx.Companies.Where(x => x.CompanyID == id).FirstOrDefault();

            return s;
        }

        public void addCompany(Company sec)
        {
            var crtx = new CortexEntities();
            crtx.Companies.Add(sec);
            crtx.SaveChanges();

        }

        public void updateCompany(Company sec)
        {
            var crtx = new CortexEntities();
            //crtx.Entry(sec).State = EntityState.Modified;
            crtx.SaveChanges();

        }

        public string GetCurrentDate()
        {
            return DateTime.Today.ToString();
        }


        //-----------------------------------------------------------------------
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
