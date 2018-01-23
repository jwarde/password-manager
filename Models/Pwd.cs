using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pass.Models
{

    public class Pwd
    {
        // Account Details Main Properties
        [Key]
        public int PwdId { get; set; }

        public DateTime? DateCreated { get; set; }


        //[Timestamp]
        //public byte[] DateTimeStamp { get; set; }


        [Display(Name = "Account Setup")]
        public bool Completed { get; set; }


        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }


        /*************************************************************/
        /***** Account Details *****/
        //public string Account_ID { get; set; }
        [Required]
        [Display(Name = "Account Name")]
        [StringLength(50, MinimumLength =5)]
        public string Account_Name { get; set; }


        [Url]
        public string URI { get; set; }


        public string Location { get; set; }


        [MinLength(6)]
        [Display(Name = "Password 1")]
        public string Password_1 { get; set; }


        //[MinLength(6)]
        //[NotMapped]
        //[Compare(nameof(Password_1), ErrorMessage = "Passwords don't match.")]
        //[Display(Name = "Re Type Password")]
        //public string Password_2 { get; set; }


        /***** Contact Details *****/
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Account Holder First Name")]
        public string Account_Holder_First_Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Account Holder Last Name")]
        public string Account_Holder_Last_Name { get; set; }


        [EmailAddress]
        [Display(Name = "Email Address Main")]
        [StringLength(50, MinimumLength = 5)]
        public string Email_Address_Main { get; set; }

        [EmailAddress]
        [Compare(nameof(Email_Address_Main), ErrorMessage = "Email Addresses don't match.")]
        [Display(Name = "Re Type Email Address")]
        [NotMapped]
        public string Email_Address_Confirmation { get; set; }


        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Phone]
        [StringLength(15)]
        [Display(Name = "Telephone")]
        public string Tel { get; set; }

        [Phone]
        [StringLength(15)]
        [Display(Name = "Mobile Telephone")]
        public string Mobile { get; set; }

        /////***** Address Details *****/
        [StringLength(70)]
        [Display(Name = "Address 1")]
        public string Address_1 { get; set; }


        [StringLength(70)]
        [Display(Name = "Address 2")]
        public string Address_2 { get; set; }


        [StringLength(30)]
        public string Town { get; set; }


        [StringLength(50)]
        public string Region { get; set; }


        [StringLength(50)]
        public string Country { get; set; }


        [Display(Name = "Post Code")]
        [StringLength(15)]
        public string Post_Code_Zip { get; set; }


        /////***** Security Question Details *****/
        [StringLength(300)]
        [Display(Name = "Question 1")]
        public string Question_1 { get; set; }


        [StringLength(250)]
        [Display(Name = "Answer 1")]
        public string Answer_1 { get; set; }


        [StringLength(300)]
        [Display(Name = "Question 2")]
        public string Question_2 { get; set; }


        [StringLength(250)]
        [Display(Name = "Answer 2")]
        public string Answer_2 { get; set; }


        [StringLength(300)]
        [Display(Name = "Question 3")]
        public string Question_3 { get; set; }


        [StringLength(250)]
        [Display(Name = "Answer 3")]
        public string Answer_3 { get; set; }


        [StringLength(300)]
        [Display(Name = "Question 4")]
        public string Question_4 { get; set; }


        [StringLength(250)]
        [Display(Name = "Answer 4")]
        public string Answer_4 { get; set; }


        [StringLength(300)]
        [Display(Name = "Question 5")]
        public string Question_5 { get; set; }


        [StringLength(250)]
        [Display(Name = "Answer 5")]
        public string Answer_5 { get; set; }


        [StringLength(50)]
        [Display(Name = "Mother Maiden Name")]
        public string Mother_Maiden_Name { get; set; }

        /***** Notes & Details *****/
        [MaxLength(5000)]
        public string Notes { get; set; }


        [MaxLength(5000)]
        public string Misc { get; set; }
    }

    public enum Category
    {

        ThirdParty,
        InHouse,
        Personal

    }

    public enum SubCategory
    {

        EMail,
        Website,
        WebApp,
        Anonymous,
        Blog,
        OS,
        DB,
        Hardware,
        Installation

    }
}