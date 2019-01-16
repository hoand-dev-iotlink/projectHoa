using ProjectAuthen.AuthenService;
using ProjectAuthen.Controllers;
using ProjectModelCommon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAuthen.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        [AllowAnonymous]
        // GET: Customer
        public ActionResult SignIn()
        {
            return View();
        }
        [AuthoriAccessAction]
        [HttpPost]
        public ActionResult SignIn(CustomerModel customerModel)
        {
            return View();
        }
    }
}