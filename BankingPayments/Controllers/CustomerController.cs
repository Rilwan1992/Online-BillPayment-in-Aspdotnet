using BankingPayments.Models;
using BankingPayments.Models.Manage_Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using BankingPayments.Models.ApprovePayments;
using Microsoft.AspNetCore.Components.Forms;

namespace BankingPayments.Controllers
{
    [Authorize(Roles = "User")]

    public class CustomerController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IBiller ibiller;
        private readonly ApplicationDbContext context;
        private readonly ICategoryinteface categoryinteface;
        private readonly IManagePayement managePayi;
        private readonly IAccount accountinterface;

        public CustomerController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, 
            IBiller ibiller, ApplicationDbContext context,ICategoryinteface categoryinteface,IManagePayement managePayi,IAccount accountinterface)
        {
            this.userManager = userManager;
            this.signInManager = signInManager; 
            this.ibiller = ibiller;
            this.context = context;
            this.categoryinteface = categoryinteface;
            this.managePayi = managePayi;
            this.accountinterface=accountinterface;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllBillers()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            string id = userId;
            
            var biller =ibiller.GetAllBillers(id);
            
            return View(biller);
        }

        [HttpGet]

        public IActionResult AddBiller()
        {
            
            var categoryList = context.Category.ToList();

            ViewBag.CategoryId =new SelectList(categoryList,"CategoryId","CategoryDesc");

            return View();
        }
        [HttpPost]
        public IActionResult AddBiller(AddBillerViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var categoryList = context.Category.ToList();

                ViewBag.CategoryId = new SelectList(categoryList, "CategoryId", "CategoryDesc");

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                BillerInfoModel billerInfoModel = new()
                {
                    BillerId = model.BillerId,
                    BillerName=model.BillerName,
                    Address=model.Address,
                    City=model.City,
                    Pin=model.Pin,
                    CategoryId = model.CategoryId,
                    CustomerId=userId
                   
                };
                ibiller.Add(billerInfoModel);
                return RedirectToAction("AllBillers");
            }
            return View(model);

        }

        [HttpGet]

        public IActionResult EditBiller(int Id)
        {
            var categoryList = context.Category.ToList();
            ViewBag.CategoryId = new SelectList(categoryList, "CategoryId", "CategoryDesc");

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            BillerInfoModel billerInfo = ibiller.GetBiller(Id);
            EditBillerViewModel billerEdit = new()
            {
               BillerName = billerInfo.BillerName,
               BillerId = billerInfo.BillerId,
               Address = billerInfo.Address,
               City=billerInfo.City,
               Pin=billerInfo.Pin,
               CategoryId=billerInfo.CategoryId,
              
            };

            return View(billerEdit);

        }

        [HttpPost]
        public IActionResult EditBiller(EditBillerViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var categoryList = context.Category.ToList();
                ViewBag.CategoryId = new SelectList(categoryList, "CategoryId", "CategoryDesc");

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                BillerInfoModel billerInfoModel = ibiller.GetBiller(model.BillerId);
                billerInfoModel.BillerName = model.BillerName;
                billerInfoModel.Address = model.Address;
                billerInfoModel.City = model.City;
                billerInfoModel.Pin = model.Pin;
                billerInfoModel.Status = model.Status;
                billerInfoModel.CategoryId = model.CategoryId;
                billerInfoModel.CustomerId = userId;
               
                ibiller.Update(billerInfoModel);
                return RedirectToAction("AllBillers");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult AllManagePayment()
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string id = userId;

            var result = context.Account.Where(c => c.CustomerId == id);           
            int Id = result.First().AccountNo;
            ViewBag.AccountNo = result.First().AccountNo;
            var payment = managePayi.GetAllPaymentInstr(Id);
            return View(payment);
        }
       

        [HttpGet]
        
        public IActionResult AddManagePayment(int Id)
        {
            ViewBag.AccountNo = Id;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string id = userId;
           
            var biller = context.BillerInfo.Where(c=>c.CustomerId == id).ToList();

            ViewBag.BillerId = new SelectList(biller, "BillerId", "BillerName");
            //int AccountNo = (int)HttpContext.Session.GetInt32("AccountNo");
            return View();
        }

        [HttpPost]
        public IActionResult AddManagePayment(AddPaymentViewModel model,int Id)
        {
            ViewBag.AccountNo = Id;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string id = userId;
            var biller = context.BillerInfo.Where(c => c.CustomerId == id).ToList();
            ViewBag.BillerId = new SelectList(biller, "BillerId", "BillerName");

            if (ModelState.IsValid)
            {              
                PaymentInstrModel paymentInstr = new()
                {
                    BillerId = model.BillerId,
                    PaymentInstrNo = model.PaymentInstrNo,                   
                    Amount = model.Amount,
                    PaymentDueDate = model.PaymentDueDate,
                    RecurringInstr = model.RecurringInstr,
                    AccountNo =Id,
                    LastProcessedDate = model.PaymentDueDate.AddMonths(1)
                };
                managePayi.Add(paymentInstr);
                return RedirectToAction("AllManagePayment");
            }
            return View(model);

        }

        [HttpGet]

        public IActionResult EditManagePayment(int Id)
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string id = userId;

            var biller = context.BillerInfo.Where(c => c.CustomerId == id).ToList();

            ViewBag.BillerId = new SelectList(biller, "BillerId", "BillerName");

            PaymentInstrModel instrModel = managePayi.GetPaymentInstr(Id);
            EditPaymentViewModel Editviewmodel = new()
            {
                PaymentInstrNo =instrModel.PaymentInstrNo,
                BillerId = instrModel.BillerId,
                Amount = instrModel.Amount,
                PaymentDueDate= instrModel.PaymentDueDate,
                RecurringInstr= instrModel.RecurringInstr,
                

            };

            return View(Editviewmodel);

        }

        [HttpPost]
        public IActionResult EditManagePayment(EditPaymentViewModel model)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string id = userId;
            var biller = context.BillerInfo.Where(c => c.CustomerId == id).ToList();
            ViewBag.BillerId = new SelectList(biller, "BillerId", "BillerName");
            var result = context.Account.Where(c => c.CustomerId == id);
            PaymentInstrModel paymentInstrModel = new()
            {
                AccountNo = result.First().AccountNo,
            };
            int AccountNo = paymentInstrModel.AccountNo;
            if (ModelState.IsValid)
            {
                PaymentInstrModel InstrModel = managePayi.GetPaymentInstr(model.PaymentInstrNo);
                InstrModel.PaymentInstrNo = model.PaymentInstrNo;
                InstrModel.Amount = model.Amount;
                InstrModel.PaymentDueDate = model.PaymentDueDate;
                InstrModel.BillerId=model.BillerId;
                InstrModel.LastProcessedDate=model.PaymentDueDate.AddMonths(1);
                InstrModel.AccountNo = AccountNo;
                

                managePayi.Update(InstrModel);
                return RedirectToAction("AllManagePayment");
            }
            return View(model);

        }


        [HttpGet]
        public IActionResult DeleteManagePayment(int Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string id = userId;

            var biller = context.BillerInfo.Where(c => c.CustomerId == id).ToList();

            ViewBag.BillerId = new SelectList(biller, "BillerId", "BillerName");



            PaymentInstrModel instrModel = managePayi.GetPaymentInstr(Id);
            DeletePaymentViewModel Deleteviewmodel = new()
            {
                PaymentInstrNo = instrModel.PaymentInstrNo,
                BillerId = instrModel.BillerId,
                Amount = instrModel.Amount,
                PaymentDueDate = instrModel.PaymentDueDate,
                RecurringInstr = instrModel.RecurringInstr,


            };

            return View(Deleteviewmodel);

        }

        [HttpPost]
        public IActionResult DeleteManagePayment(DeletePaymentViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string id = userId;
            var biller = context.BillerInfo.Where(c => c.CustomerId == id).ToList();
            ViewBag.BillerId = new SelectList(biller, "BillerId", "BillerName");
            var result = context.Account.Where(c => c.CustomerId == id);
            PaymentInstrModel paymentInstrModel = new()
            {
                AccountNo = result.First().AccountNo,
            };
            int AccountNo = paymentInstrModel.AccountNo;
            if (ModelState.IsValid)
            {
                PaymentInstrModel InstrModel = managePayi.GetPaymentInstr(model.PaymentInstrNo);
                InstrModel.PaymentInstrNo = model.PaymentInstrNo;
                InstrModel.Amount = model.Amount;
                InstrModel.PaymentDueDate = model.PaymentDueDate;
                InstrModel.BillerId = model.BillerId;
                InstrModel.LastProcessedDate = model.PaymentDueDate.Date;
                InstrModel.AccountNo = AccountNo;
                managePayi.Delete(InstrModel.PaymentInstrNo);
                return RedirectToAction("AllManagePayment");
            }
            return View(model);
            
        }       

      
        [HttpGet]
        public IActionResult ViewPayment()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult ViewPayment(DateTime Fromdate,DateTime ToDate)
        {
           
            if (ToDate < Fromdate)
            {
                ViewBag.ErrorMessege = "Todate should not be less than From Date";
            }
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string id = userId;
                var result = context.Account.Where(c => c.CustomerId == id);
                var paymentdata = context.Payment.Where(c => c.AccountNo == result.First().AccountNo && c.PaymentDate >= Fromdate && c.PaymentDate <= ToDate)
                                                            .Include(b => b.BillerInfoModel).Include(ca => ca.CategoryModel);
                ViewBag.Payment = paymentdata;                
                return View(paymentdata);

            }
            return View();
        }


    }
}
