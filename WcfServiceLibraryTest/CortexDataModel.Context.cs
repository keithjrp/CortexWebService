﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CortexEntities : DbContext
    {
        public CortexEntities()
            : base("name=CortexEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyAssociation> CompanyAssociations { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DocumentGroup> DocumentGroups { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<SecurityGroup> SecurityGroups { get; set; }
        public DbSet<SecurityType> SecurityTypes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}