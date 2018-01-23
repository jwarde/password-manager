using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pass.Models
{
    public class PassDbContext : DbContext
    {
        public PassDbContext(): base("name=PassDBstr") 
        {
        }

        public DbSet<Pwd> Pwd { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pwd>().Map(m =>
            {
                m.Properties(p => new { p.PwdId, p.DateCreated, p.Completed, p.Category, p.SubCategory });
                m.ToTable("AccountDetailsMain");

            }).Map(m => {
                m.Properties(p => new { p.Account_Name, p.URI, p.Location, p.Password_1});
                m.ToTable("AccountDetails");

            }).Map(m => {
                m.Properties(p => new { p.Account_Holder_First_Name, p.Account_Holder_Last_Name, p.Email_Address_Main, p.DOB, p.Tel, p.Mobile });
                m.ToTable("ContactDetails");

            }).Map(m => {
                m.Properties(p => new { p.Address_1, p.Address_2, p.Town, p.Region, p.Country, p.Post_Code_Zip });
                m.ToTable("AddressDetails");

            }).Map(m => {
                m.Properties(p => new { p.Question_1, p.Answer_1, p.Question_2, p.Question_3, p.Answer_3, p.Question_4, p.Answer_4, p.Question_5, p.Answer_5 , p.Mother_Maiden_Name });
                m.ToTable("SecurityDetails");

            }).Map(m => {
                m.Properties(p => new { p.Notes, p.Misc });
                m.ToTable("Notes");

            });


        }

    }
}