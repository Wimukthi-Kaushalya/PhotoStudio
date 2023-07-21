using PhotoStudio.Data;
using PhotoStudio.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhotoStudio.Controllers
{

    public class HomeController : Controller
    {

        PhotoStudio_DBEntities db = new PhotoStudio_DBEntities();


        ////Create or add Login Page to the system
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }




        ////Create or add Index Page to the system
        public ActionResult Index()
        {
            return View();
        }


        //////Create or add  About Us to the system
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}



        public ActionResult ViewUser()
        {
            var user = db.tbl_User;
            return View(user);

        }

        ////Create or add  AddUser Us to the system
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User U)
        {
            var Fname = U.FirstName;
            var Lname = U.LastName;
            var DOB = U.DOB;
            var Address = U.Address;
            var ContactNumber = U.ContactNum;
            var Email = U.EmailAddress;
            var Password = U.Password;
            var UserType = U.UserType;
            var BranchId = U.BrachID;

            //int Manager = Convert.ToInt32(BManager);
            //int branchNumber = Convert.ToInt32(Bnumber);

            db.Database.ExecuteSqlCommand("EXEC Pro_CreateNewUser @FirstName,@LastName,@DOB,@Address,@ContactNumber,@Email,	@Password,@UserType,@BranchId",

                new SqlParameter("@FirstName", Fname),
                new SqlParameter("@LastName", Lname),
                new SqlParameter("@DOB", DOB),
                new SqlParameter("@Address", Address),
                new SqlParameter("@ContactNumber", ContactNumber),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Password", Password),
                new SqlParameter("@UserType", UserType),
                new SqlParameter("@BranchId", BranchId)
                );

            db.SaveChanges();


            return View("ViewUser");
        }




        ////Create or add Chaarge Type to the system

        public ActionResult CreateChargeType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateChargeType(ChargeType C)
        {
            var ChargeTypeCode = C.ChargeTypeCode;
            var Discription = C.Discription;
            var EventType = C.EventType;
            var Price = C.Price;

            //int Manager = Convert.ToInt32(BManager);
            //int branchNumber = Convert.ToInt32(Bnumber);

            db.Database.ExecuteSqlCommand("EXEC Pro_Create_ChargTyperef @ChargeTypeCode,@Discription,@EventType,@Price",

                new SqlParameter("@ChargeTypeCode", ChargeTypeCode),
                new SqlParameter("@Discription", Discription),
                new SqlParameter("@EventType", EventType),
                new SqlParameter("@Price", Price)
                );

            db.SaveChanges();

            return View("CreateChargeType");
        }




        public ActionResult ViewChargeType()
        {

            var ViewChargeType = db.tbl_ChargTyperef;
            return View(ViewChargeType);
        }


        ////Create or add Branch  to the system
        public ActionResult CreateBranch()
        {
            return View();
        }

        //  1 Create copy
        // 2 Combine modal called branch
        [HttpPost]
        public ActionResult CreateBranch(Branch branch)
        {
            try
            {
                var BName = branch.BranchName;
                var Baddress = branch.Address;
                var Bnumber = branch.ContactNumbe;
                var BManager = branch.MangerID;
                var BEmail = branch.BranchEmail;

                int Manager = Convert.ToInt32(BManager);
                int branchNumber = Convert.ToInt32(Bnumber);

                db.Database.ExecuteSqlCommand("EXEC Pro_CreateNewBranch @BranchName,@Address,@ContactNumber,@Email,@Manager",
                    new SqlParameter("@BranchName", BName),
                    new SqlParameter("@Address", Baddress),
                    new SqlParameter("@ContactNumber", branchNumber),
                    new SqlParameter("@Email", BEmail),
                    new SqlParameter("@Manager", Manager)

                    );

                int returnValue = db.Database.ExecuteSqlCommand("EXEC Pro_CreateNewBranch @BranchName,@Address,@ContactNumber,@Email,@Manager",
                      new SqlParameter("@BranchName", BName),
                      new SqlParameter("@Address", Baddress),
                      new SqlParameter("@ContactNumber", branchNumber),
                      new SqlParameter("@Email", BEmail),
                      new SqlParameter("@Manager", Manager)
                );


                db.SaveChanges();

                if (returnValue == -1)
                {
                    // Return an error message to the view
                    //return Content("An error occurred while creating the branch.");
                    //return Json(new { success = true, message = "Branch fill successfully." });
                    return Json(new { success = false, message = "Please Fill all the details ." });

                }


                return RedirectToAction("ViewBranch");
                //return Json(new { success = true, message = "Branch created successfully." });

            }


            catch (Exception ex)
            {
                // Handle other exceptions here if needed
                //return Content("An error occurred: " + ex.Message);

                ViewBag.ErrorMessage = ex.Message.ToString();
                return View("CreateBranch");
                //return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }


        public ActionResult ViewBranch()
        {
            var ViewBranch = db.tbl_Branch;
            return View(ViewBranch);
        }

        //-
        public ActionResult EditBranch(Branch BB)
        {


            var id = Request["BID"];
            int A = Convert.ToInt32(id);

            tbl_Branch TblB = db.tbl_Branch.SingleOrDefault(x => x.BarnchID == A);

            BB.BarnchID = TblB.BarnchID;
            BB.BranchName = TblB.BranchName;
            BB.Address = TblB.Address;
            BB.ContactNumbe = TblB.ContactNumbe;
            BB.BranchEmail = TblB.BranchEmail;
            BB.MangerID = TblB.MangerID;

            using (var context = new PhotoStudio_DBEntities())
            {
                BB.BranchList = context.tbl_Branch.Select(b => b.BarnchID).ToList();

            }
            return View(BB);
        }



        public async Task<ActionResult> UpdateBranch(Branch branch)
        {



            try
            {

                var entity = await db.tbl_Branch.FindAsync(branch.BarnchID);
                if (entity != null)
                {
                    entity.BranchName = branch.BranchName;
                    entity.BranchEmail = branch.BranchEmail;
                    entity.ContactNumbe = branch.ContactNumbe;
                    entity.Address = branch.Address;



                    await db.SaveChangesAsync();
                    return RedirectToAction("ViewBranch");
                }
                ViewBag.Error = "Branch not found";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error updating Branch: " + ex.Message;
            }
            return RedirectToAction("ViewBranch");
        }






        //-----------

        ////Create or add AddBooking_Admin  to the system

        public ActionResult AddBooking_Admin()
        {
            return View();
        }


        ////Create or add AddBooking_User  to the system
        public ActionResult AddBooking_User()
        {
            return View();
        }


        ////Create or add create Accoun  to the system
        public ActionResult CreateAccount()
        {
            return View();
        }


        public ActionResult ViewAccount()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateAccount(Account A)
        {
            var CustometTitle = A.CustometTitle;
            var CustomerFName = A.CustomerFName;
            var CustomerLName = A.CustomerLName;
            var CustomerAddress1 = A.CustomerAddress1;
            var CustomerAddress2 = A.CustomerAddress2;
            var CustomerAddress3 = A.CustomerAddress3;
            var CutomerContact = A.CutomerContact;
            var CustomerEmail = A.CustomerEmail;
            var RegistrerdDate = DateTime.Today;

            var Password = Request["password"];

            //int Manager = Convert.ToInt32(BManager);
            //int branchNumber = Convert.ToInt32(Bnumber);

            db.Database.ExecuteSqlCommand("EXEC Pro_Create_NewCustomer @CustometTitle,@CustomerFName,@CustomerLName,@CustomerAddress1,@CustomerAddress2,@CustomerAddress3,@CutomerContact,@CustomerEmail,@RegistrerdDate,@Password",

                new SqlParameter("@CustometTitle", CustometTitle),
                new SqlParameter("@CustomerFName", CustomerFName),
                new SqlParameter("@CustomerLName", CustomerLName),
                new SqlParameter("@CustomerAddress1", CustomerAddress1),
                new SqlParameter("@CustomerAddress2", CustomerAddress2),
                new SqlParameter("@CustomerAddress3", CustomerAddress3),
                new SqlParameter("@CutomerContact", CutomerContact),
                new SqlParameter("@CustomerEmail", CustomerEmail),
                new SqlParameter("@RegistrerdDate", RegistrerdDate),
                new SqlParameter("@Password", Password)
                );

            db.SaveChanges();


            return View("CreateAccount");
        }




        public async Task<ActionResult> Delete_Branch()
        {
            var aid_D = Request["BID"];
            int AID = Convert.ToInt32(aid_D);

            var entity = await db.tbl_Branch.FindAsync(AID);

            if (entity != null)
            {
                db.tbl_Branch.Remove(entity);
                db.SaveChanges();
                await db.SaveChangesAsync();
                return RedirectToAction("ViewAllocations");
            }
            ViewBag.Error = "Somthing went wrong";
            return View(ViewBag.Error);





        }
    }
}