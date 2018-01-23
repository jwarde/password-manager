using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pass.Models;

namespace Pass.Controllers
{
    [Authorize]
    public class PwdsController : Controller
    {
        
        private PassDbContext db = new PassDbContext();

        // GET: Pwds
        public ActionResult Index()
        {
            return View(db.Pwd.ToList());
        }

        // GET: Pwd /Pwds/Category?SubCatName=
        public ActionResult SubCategory(string SubCatName)
        {
            //SubCategory SubCategoryName = (SubCategory)Enum.Parse(
            //typeof(SubCategory), SubCatName, true);


            //return View("SubCategory", db.Pwd.Where(cn => cn.SubCategory == SubCategoryName).ToList());


            if (SubCatName == "EMail" || SubCatName == "Website" || SubCatName == "WebApp" || SubCatName == "Anonymous" || SubCatName == "Blog" || SubCatName == "OS" || SubCatName == "DB" || SubCatName == "Hardware" || SubCatName == "Installation")
            {
                //Category CategoryName = (Category)Enum.Parse(
                //typeof(Category), CatName, true);

                SubCategory EMail =
                (SubCategory)Enum.Parse(typeof(SubCategory), "EMail");

                SubCategory Website =
                (SubCategory)Enum.Parse(typeof(SubCategory), "Website", true);

                SubCategory WebApp =
                (SubCategory)Enum.Parse(typeof(SubCategory), "WebApp", true);

                SubCategory Anonymous =
                (SubCategory)Enum.Parse(typeof(SubCategory), "Anonymous", true);

                SubCategory Blog =
                (SubCategory)Enum.Parse(typeof(SubCategory), "Blog", true);

                SubCategory OS =
                (SubCategory)Enum.Parse(typeof(SubCategory), "OS", true);

                SubCategory DB =
                (SubCategory)Enum.Parse(typeof(SubCategory), "DB", true);

                SubCategory Hardware =
                (SubCategory)Enum.Parse(typeof(SubCategory), "Hardware", true);

                SubCategory Personal =
                (SubCategory)Enum.Parse(typeof(SubCategory), "Installation", true);



                SubCategory SubCategoryName = (SubCategory)Enum.Parse(
                typeof(SubCategory), SubCatName, true);

                ViewBag.SubCategoryVB = SubCatName;

                var model = db.Pwd.Where(cn => SubCatName == null || cn.SubCategory == SubCategoryName).ToList();

                return View("SubCategory", model);
            }
            else
            {

                return View("NullCategory");

            }

        }

        // GET: Pwd /Pwds/Category?CatName=
        public ActionResult Category(string CatName)
        {
            //var thirdpartycount = db.Pwd.Where(cn => cn.(Category)Category == "ThirdParty").Select.ToList();


            if (CatName == "ThirdParty" || CatName == "InHouse" || CatName == "Personal")
            {
                //Category CategoryName = (Category)Enum.Parse(
                //typeof(Category), CatName, true);

                Category ThirdParty =
                (Category)Enum.Parse(typeof(Category), "ThirdParty");

                Category InHouse =
                (Category)Enum.Parse(typeof(Category), "InHouse", true);

                Category Personal =
                (Category)Enum.Parse(typeof(Category), "Personal", true);

                Category CategoryName = (Category)Enum.Parse(
                typeof(Category), CatName, true);

                ViewBag.CategoryVB = CatName;

                var model = db.Pwd.Where(cn => CatName == null || cn.Category == CategoryName).ToList();

                return View("Category", model);
            }
            else{

                return View("NullCategory");

            }


        }

        // GET: Pwds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pwd pwd = db.Pwd.Find(id);
            if (pwd == null)
            {
                return HttpNotFound();
            }
            return View(pwd);
        }

        // GET: Pwds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pwds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PwdId,DateCreated,DateTimeStamp,Completed,Category,SubCategory,Account_Name,URI,Location,Password_1,Account_Holder_First_Name,Account_Holder_Last_Name,Email_Address_Main,DOB,Tel,Mobile,Address_1,Address_2,Town,Region,Country,Post_Code_Zip,Question_1,Answer_1,Question_2,Answer_2,Question_3,Answer_3,Question_4,Answer_4,Question_5,Answer_5,Mother_Maiden_Name,Notes,Misc")] Pwd pwd)
        {


            if (ModelState.IsValid)
            {

                pwd.DateCreated = DateTime.Today; // set date before saving = DateTime.Today; // set date before saving

                db.Pwd.Add(pwd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pwd);
        }

        // GET: Pwds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pwd pwd = db.Pwd.Find(id);
            if (pwd == null)
            {
                return HttpNotFound();
            }
            return View(pwd);
        }

        // POST: Pwds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PwdId,DateCreated,DateTimeStamp,Completed,Category,SubCategory,Account_Name,URI,Location,Password_1,Account_Holder_First_Name,Account_Holder_Last_Name,Email_Address_Main,DOB,Tel,Mobile,Address_1,Address_2,Town,Region,Country,Post_Code_Zip,Question_1,Answer_1,Question_2,Answer_2,Question_3,Answer_3,Question_4,Answer_4,Question_5,Answer_5,Mother_Maiden_Name,Notes,Misc")] Pwd pwd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pwd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pwd);
        }

        // GET: Pwds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pwd pwd = db.Pwd.Find(id);
            if (pwd == null)
            {
                return HttpNotFound();
            }
            return View(pwd);
        }

        // POST: Pwds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pwd pwd = db.Pwd.Find(id);
            db.Pwd.Remove(pwd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
