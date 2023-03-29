using BankingPayments.Models;
using BankingPayments.Models.ApprovePayments;
using BankingPayments.Models.Manage_Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankingPayments.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext context;
        private readonly ICategoryinteface categoryinteface;
        private readonly IAccount iaccount;
        private readonly IApprovePayment approvePayment;
        private readonly IManagePayement managePayi;

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
            , RoleManager<IdentityRole> roleManager, ICategoryinteface categoryinteface, ApplicationDbContext context, 
            IAccount iaccount, IApprovePayment approvePayment, IManagePayement managePayi)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.categoryinteface = categoryinteface;
            this.context = context;
            this.iaccount = iaccount;
            this.approvePayment = approvePayment;
            this.managePayi= managePayi;  
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //To Create a Online User for banking

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Registration(Registration model)
        {
            var user = new ApplicationUser
            {
                
                UserName = model.UserName,
                CustomerName = model.CustomerName,
                // Password = model.Password
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                TempData["CustomerId"]= user.Id;
                //await signInManager.SignInAsync(user,isPersitent:false);
                return RedirectToAction("UserAccount",new { id = user.Id });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        //Create Roles

        [HttpGet]

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new()
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllRoles", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        //Edit Roles

        [HttpGet]
        public async Task<IActionResult> EditRoles(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role Id {id} Not Found";
                return View("NotFound");

            }
            var model = new EditViewModel
            {
                RoleName = role.Name,
                Id = id

            };
            foreach (var user in userManager.Users.ToList())
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoles(EditViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role Id {model.Id} Not Found";
                return View("NotFound");

            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        //Delete Roles

        [HttpGet]
        public async Task<IActionResult> DeleteRoles(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role Id {id} Not Found";
                return View("NotFound");

            }
            var model = new DeleteRoleViewModel
            {
                RoleName = role.Name,
                Id = id

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRoles(DeleteRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role Id {model.Id} Not Found";
                return View("NotFound");

            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        // Create Roles for Users
        [HttpGet]
        public async Task<IActionResult> EditUserinRoles(string Id)
        {
            ViewBag.roleId = Id;
            var role = await roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} cannot be found";
                return View("NotFound");
            }

            var model = new List<EditUserRole>();
            foreach (var user in userManager.Users)
            {
                var EditUserRole = new EditUserRole
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    EditUserRole.IsSelected = true;
                }
                else
                {
                    EditUserRole.IsSelected = false;
                }
                model.Add(EditUserRole);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserinRoles(List<EditUserRole> model, string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result;
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRoles", new { Id });
                    }
                }

            }
            return RedirectToAction("EditRoles", new { Id });

        }
        // To Delete User Roles
        [HttpGet]
        public async Task<IActionResult> DeleteUserinRole(string Id)
        {
            ViewBag.roleId = Id;
            var role = await roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} cannot be found";
                return View("NotFound");
            }

            var model = new List<DeleteUserRole>();
            foreach (var user in userManager.Users)
            {
                var DeleteUserRole = new DeleteUserRole
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    DeleteUserRole.IsSelected = true;
                }
                else
                {
                    DeleteUserRole.IsSelected = false;
                }
                model.Add(DeleteUserRole);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserinRole(List<DeleteUserRole> model, string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result;


                if (model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRoles", new { Id });
                    }
                }

            }
            return RedirectToAction("EditRoles", new { Id });

        }
        //All Categories
        [HttpGet]
        public IActionResult AllCategory()
        {
            var category = categoryinteface.GetAllCategories();
            return View(category);
        }

        //Add Category
        [HttpGet]

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddCategory(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                CategoryModel categoryModel = new()
                {
                    CategoryId = model.CategoryId,
                    CategoryDesc = model.CategoryDesc
                };
                categoryinteface.Add(categoryModel);
                TempData["success"] = "Employee Data Created Successfully";
                return RedirectToAction("AllCategory");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            CategoryModel categoryModel = categoryinteface.GetCategories(id);
            CategoryEditViewModel categoryEdit = new()
            {
                CategoryId = categoryModel.CategoryId,
                CategoryDesc = categoryModel.CategoryDesc
            };

            return View(categoryEdit);

            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}
            //var CategoryList = context.Category.Find(id);
            //if (CategoryList == null)
            //{
            //    return NotFound();
            //}
            //return View(CategoryList);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                CategoryModel categoryModel = categoryinteface.GetCategories(model.CategoryId);
                categoryModel.CategoryDesc = model.CategoryDesc;
                categoryinteface.Update(categoryModel);
                TempData["success"] = "Employee Data Created Successfully";
                return RedirectToAction("AllCategory");
            }
            return View(model);

        }

        [HttpGet]

        public IActionResult UserAccount(string id)
        {
            ViewBag.CustomerId = id;
            return View();
        }

        [HttpPost]

        public IActionResult UserAccount(AddAccountViewModel addAccount,string id)
        {
            if (ModelState.IsValid)
            {
                AccountModel accountModel = new()
                {
                    AccountNo = addAccount.AccountNo,
                    AcType = addAccount.AcType,
                    AccountBalance = addAccount.AccountBalance,
                    CustomerId = id
                };
                iaccount.Add(accountModel);
                return RedirectToAction("Index","Admin");
            }
            return View(addAccount);
        }

        [HttpGet]

        public IActionResult ApprovePayments()
        {
            var payment = approvePayment.GetAllPayments();
            return View(payment);
        }

        [HttpGet]
        public IActionResult FinalNoApprove(int Id)
        {
            PaymentInstrModel paymentInstr = approvePayment.GetPayment(Id);
            FinalApprove final = new()
            {
                PaymentInstrNo = paymentInstr.PaymentInstrNo,
                date=paymentInstr.PaymentDueDate,
                AccountNo= paymentInstr.AccountNo,
                Amount=paymentInstr.Amount,
                AccountBalance=paymentInstr.AccountModel.AccountBalance,
                RecurringInstr=paymentInstr.RecurringInstr,
                LastProcessedDate=paymentInstr.LastProcessedDate,
                

            };
            return View(final);
        }

        [HttpPost]
        public IActionResult FinalNoApprove(FinalApprove finalApprove)            
        {
            if (ModelState.IsValid) 
            {
                
                PaymentInstrModel InstrModel = approvePayment.GetPayment(finalApprove.PaymentInstrNo);
                InstrModel.PaymentInstrNo = finalApprove.PaymentInstrNo;
                InstrModel.PaymentDueDate = finalApprove.date;
                InstrModel.Amount = finalApprove.Amount;
                InstrModel.AccountNo = finalApprove.AccountNo;
                InstrModel.LastProcessedDate= finalApprove.LastProcessedDate;
                InstrModel.RecurringInstr= finalApprove.RecurringInstr;
                InstrModel.BillerId = finalApprove.BillerId;
                
                approvePayment.Delete(InstrModel.PaymentInstrNo);
                return RedirectToAction("ApprovePayments");

            }
            return View(finalApprove);
        }


        [HttpGet]
        public IActionResult FinalYesApprove(int Id)
        {
            PaymentInstrModel paymentInstr = approvePayment.GetPayment(Id);
            FinalApprove final = new()
            {
                PaymentInstrNo = paymentInstr.PaymentInstrNo,
                date = paymentInstr.PaymentDueDate,
                AccountNo = paymentInstr.AccountNo,
                Amount = paymentInstr.Amount,
                AccountBalance = paymentInstr.AccountModel.AccountBalance,
                RecurringInstr = paymentInstr.RecurringInstr,
                LastProcessedDate = paymentInstr.LastProcessedDate,
            };
            return View(final);
        }

        [HttpPost]
        public IActionResult FinalYesApprove(FinalApprove final)
        {
            if (ModelState.IsValid)
            {
                PaymentInstrModel InstrModel = approvePayment.GetPayment(final.PaymentInstrNo);

                decimal sub = InstrModel.AccountModel.AccountBalance - InstrModel.Amount;
                AccountModel accountModel = context.Account.Where(c=>c.AccountNo == InstrModel.AccountNo).First();
                accountModel.AccountBalance = sub;
                var act = context.Account.Attach(accountModel);
                act.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                var date = DateTime.Now;
                //var data = context.PaymentInstr.Where(c => c.PaymentInstrNo == finalApprove.PaymentInstrNo).Include(ca => ca.CategoryModel).ToList();
                var data = context.BillerInfo.Where(c=> c.BillerId == InstrModel.BillerId).Include(d=>d.CategoryModel);
                var category = data.First().CategoryModel.CategoryId;
                PaymentModel paymentModel = new()
                {
                    AccountNo = InstrModel.AccountNo,
                    BillerId = InstrModel.BillerId,
                    PaymentDate = date,
                    Amount = InstrModel.Amount,
                    CategoryId = category,

                };
                context.Payment.Add(paymentModel);
                context.SaveChanges();
                if (InstrModel.RecurringInstr == 2)
                {                  
                    approvePayment.Delete(InstrModel.PaymentInstrNo);
                    return RedirectToAction("ApprovePayments");
                }
                else
                {
                    PaymentInstrModel paymentInstr = context.PaymentInstr.Where(c => c.PaymentInstrNo == InstrModel.PaymentInstrNo).First();
                    paymentInstr.LastProcessedDate = DateTime.Now;
                    paymentInstr.PaymentDueDate = DateTime.Now.AddMonths(1);
                    context.PaymentInstr.Update(paymentInstr);
                    context.SaveChanges();
                    return RedirectToAction("ApprovePayments");
                }

            }
            return View(final);


        }








    }
}
