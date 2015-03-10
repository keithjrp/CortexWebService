using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CortexWebService;

namespace CortexWebService
{
    public static class CortexClone
    {
        /// <summary>
        /// Partial copy of a Deal
        /// </summary>
        /// <returns></returns>
        public static Deal clone(Deal x)
        {
            try
            {
                Deal cloneDeal = new Deal()
                {
                    DealID = x.DealID,
                    Description = x.Description,
                    InvestmentThesis = x.InvestmentThesis,
                    Recommendation = x.Recommendation,
                    TargetPrice = x.TargetPrice,
                    CompanyID1 = x.CompanyID1 == null ? 0 : x.CompanyID1,
                    CompanyID2 = x.CompanyID2 == null ? 0 : x.CompanyID2,
                    CompanyID3 = x.CompanyID3 == null ? 0 : x.CompanyID3,
                    DocumentGroupID = x.DocumentGroupID == null ? 0 : x.DocumentGroupID,
                    CurrencyID = x.CurrencyID == null ? 0 : x.CurrencyID,
                    SecurityGroupID = x.SecurityGroupID == null ? 0 : x.SecurityGroupID,
                    DropDeadEventID = x.DropDeadEventID == null ? 0 : x.DropDeadEventID,
                    MergerAgreementEventID = x.MergerAgreementEventID == null ? 0 : x.MergerAgreementEventID,
                    AcquirerShareholderMeetingEventID = x.AcquirerShareholderMeetingEventID == null ? 0 : x.AcquirerShareholderMeetingEventID,
                    TargetShareholderMeetingEventID = x.TargetShareholderMeetingEventID == null ? 0 : x.TargetShareholderMeetingEventID,
                    DealCurrencyID = x.DealCurrencyID == null ? 0 : x.DealCurrencyID,
                    TargetPriceValuation = x.TargetPriceValuation == null ? "" : x.TargetPriceValuation,
                    CurrentValuation = x.CurrentValuation == null ? "" : x.CurrentValuation,
                    Catalyst = x.Catalyst == null ? "" : x.Catalyst,
                    KeyRisks = x.KeyRisks == null ? "" : x.KeyRisks,
                    ValuationMethodology = x.ValuationMethodology == null ? "" : x.ValuationMethodology,
                    Background = x.Background == null ? "" : x.Background,
                    DownsidePrice = x.DownsidePrice,
                    DownsidePriceValuation = x.DownsidePriceValuation == null ? "" : x.DownsidePriceValuation,
                    Comps = x.Comps == null ? "" : x.Comps,
                    DealTypeID = x.DealTypeID == null ? 0 : x.DealTypeID,
                    ExpirationDate = x.ExpirationDate == null ? DateTime.Now : x.ExpirationDate,
                    DealStatusID = x.DealStatusID == null ? 0 : x.DealStatusID,
                    CategoryID = x.CategoryID == null ? 0 : x.CategoryID

                };
                return cloneDeal;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Deal\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// return partial Copy of a Event, else a null
        /// </summary>
        /// <returns></returns>
        public static DocumentGroup clone(DocumentGroup x)
        {
            try
            {
                DocumentGroup DocumentGroupClone = new DocumentGroup()
                {
                    DocumentGroupID = x.DocumentGroupID,
                    //DocumentID1 = x.DocumentID1 == null ? 0 : x.DocumentID1,
                    //DocumentID2 = x.DocumentID2 == null ? 0 : x.DocumentID2,
                    //DocumentID3 = x.DocumentID3 == null ? 0 : x.DocumentID3,

                };

                return DocumentGroupClone;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning DocumentGroup \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// partial Copy of a Company
        /// </summary>
        /// <returns></returns>
        public static Company clone(Company x)
        {
            try
            {
                Company compClone = new Company()
                {
                    CompanyID = x.CompanyID,
                    Code = x.Code,
                    Description = x.Description,
                    Name = x.Name
                };
                return compClone;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Company \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// partial Copy of a CompanyAssociation
        /// </summary>
        /// <returns></returns>
        public static CompanyAssociation clone(CompanyAssociation x)
        {
            try
            {
                CompanyAssociation compClone = new CompanyAssociation()
                {
                    CompanyAssociationID = x.CompanyAssociationID,
                    Company1ID = x.Company1ID,
                    Company2ID = x.Company2ID
                };
                return compClone;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning CompanyAssociation \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// return partial Copy of a Currency, else a null
        /// </summary>
        /// <returns></returns>
        public static Currency clone(Currency x)
        {
            try
            {
                Currency currClone = new Currency()
                {
                    CurrencyID = x.CurrencyID,
                    CurrencyCode = x.CurrencyCode,
                    CurrencyName = x.CurrencyName
                };
                return currClone;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Currency \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// return partial Copy of a Document, else a null
        /// </summary>
        /// <returns></returns>
        public static Document clone(Document x)
        {
            try
            {
                Document docClone = new Document()
                {
                    DocumentID = x.DocumentID,
                    Name = x.Name,
                    Description = x.Description,
                    URI = x.URI,
                    DealId = (int)x.DealId
                };
                return docClone;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Document \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// return partial Copy of a Event, else a null
        /// </summary>
        /// <returns></returns>
        public static Event clone(Event x)
        {
            try
            {
                Event eventClone = new Event()
                {
                    EventID = x.EventID,
                    EventDate = x.EventDate,
                    Description = x.Description,
                    EventTypeID = x.EventTypeID,
                    Note = x.Note,
                    DealID = x.DealID
                };

                return eventClone;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Event \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// return partial Copy of a EventType, else a null
        /// </summary>
        /// <returns></returns>
        public static EventType clone(EventType x)
        {
            try
            {
                EventType EventTypeClone = new EventType()
                {
                    EventTypeID = x.EventTypeID,
                    Code = x.Code,
                    Description = x.Description,
                    Name = x.Name
                };

                return EventTypeClone;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning EventType \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// partial Copy of a Security
        /// </summary>
        /// <returns></returns>
        public static Security clone(Security x)
        {
            try
            {
                Security cloneSecurity = new Security()
                {
                    SecurityID = x.SecurityID,
                    Code = x.Code,
                    Description = x.Description,
                    Name = x.Name,
                    CurrencyID = x.CurrencyID,
                    SecurityTypeID = x.SecurityTypeID,
                    Cusip = x.Cusip,
                    Isin = x.Isin,
                    Sedol = x.Sedol,
                    Ticker = x.Ticker
                };
                return cloneSecurity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Security \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// partial Copy of a SecurityGroup
        /// </summary>
        /// <returns></returns>
        public static SecurityGroup clone(SecurityGroup x)
        {
            try
            {
                SecurityGroup cloneSecurity = new SecurityGroup()
                {
                    SecurityGroupID = x.SecurityGroupID,
                    SecurityID1 = x.SecurityID1,
                    SecurityID2 = x.SecurityID2 == null ? 0 : x.SecurityID2,
                    SecurityID3 = x.SecurityID3 == null ? 0 : x.SecurityID3,
                    SecurityID4 = x.SecurityID4 == null ? 0 : x.SecurityID4,
                    SecurityID5 = x.SecurityID5 == null ? 0 : x.SecurityID5

                };
                return cloneSecurity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning SecurityGroup \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// partial Copy of a SecurityType
        /// </summary>
        /// <returns></returns>
        public static SecurityType clone(SecurityType x)
        {
            try
            {
                SecurityType cloneSecurity = new SecurityType()
                {
                    Code = x.Code,
                    Description = x.Description,
                    Name = x.Name,
                    SecurityTypeID = x.SecurityTypeID

                };
                return cloneSecurity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning SecurityType \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static AnnualCompanyStatistic clone(AnnualCompanyStatistic x)
        {
            try
            {
                AnnualCompanyStatistic a = new AnnualCompanyStatistic()
                {
                   AnnualCompanyStatisticID = x.AnnualCompanyStatisticID,
                    CompanyID = x.CompanyID,
                    Year = x.Year,
                    StatisticTypeID = x.StatisticTypeID,
                    Value = x.Value,
                    Source = x.Source
                };
                return a;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning AnnualCompanyStatistic \n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DealType clone(DealType x)
        {
            try
            {
                DealType d = new DealType()
                {
                    DealTypeID = x.DealTypeID,
                    Code = x.Code,
                    Name = x.Name
                };
                return d;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning DealType\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Price clone(Price x)
        {
            try
            {
                Price p = new Price()
                {
                    PriceID = x.PriceID,
                    SecurityID = x.SecurityID,
                    Price1 = x.Price1,
                    PriceDateTime = x.PriceDateTime,
                    PriceSource = x.PriceSource
                };

                return p;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Price\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static StatisticType clone(StatisticType x)
        {
            try
            {
                StatisticType s = new StatisticType()
                {
                    StatisticTypeID = x.StatisticTypeID,
                    Name = x.Name,
                    Code = x.Code

                };

                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning StatisticType\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static DealStatus clone(DealStatus x)
        {
            try
            {
                DealStatus d = new DealStatus()
                {
                    DealStatusID = x.DealStatusID,
                    Name = x.Name,
                    Code = x.Code
                };

                return d;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning DealStatus\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static MapDealAnalyst clone(MapDealAnalyst x)
        {
            try
            {
                MapDealAnalyst m = new MapDealAnalyst()
                {
                    IsLeadAnalyst = x.IsLeadAnalyst,
                    AnalystID = x.AnalystID,
                    DealID = x.DealID,
                    MapDealAnalystID = x.MapDealAnalystID
                };
                return m;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning MapDealAnalyst\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Category clone(Category x)
        {
            try
            {
                Category c = new Category()
                {
                    CategoryID = x.CategoryID,
                    Class = x.Class,
                    Name = x.Name
                };
                return c;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Category\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        public static Analyst clone(Analyst x)
        {
            try
            {
                Analyst a = new Analyst()
                {
                    AnalystID = x.AnalystID,
                    Login = x.Login,
                    Password = x.Password
                };

                return a;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cloning Analyst\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

    }
}