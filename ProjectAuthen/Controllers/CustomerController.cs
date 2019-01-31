using Newtonsoft.Json;
using ProjectAuthen.AuthenService;
using ProjectAuthen.Controllers;
using ProjectModelCommon.Model;
using ProjectModelCommon.ViewModel;
using ProjectService.CommonService;
using ProjectService.DatacontextRep;
using ProjectService.InterfaceRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectAuthen.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        ACustomerRep aCustomerRep = new CustomerRep();
        ACustomerRep customerService = new CustomerService();
        [AllowAnonymous]
        // GET: Customer
        public ActionResult SignIn(string returnUrl)
        {
            if (User == null)
                return View();
            return RedirectToAction("index", "home");
        }
        //[AuthoriAccessAction]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> SignIn(CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                customerModel.PassWord = await customerService.SetHashPassword(customerModel.PassWord, GetConfig());
                var customer = await this.aCustomerRep.SignIn(customerModel);
                if (CreateCookie(customer))
                    return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// SignUp
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult SignUp(string returnUrl)
        {
            if (User == null)
                return View();
            return RedirectToAction("index","home");
        }

        /// <summary>
        /// sign up
        /// </summary>
        /// <param name="customerUserModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(CustomerUser customerUserModel)
        {
            //string body = html();
            //bool check = await customerService.SendMail(customerUserModel.Email, "test hòa", body);
            if (ModelState.IsValid)
            {
                customerUserModel.Password = await customerService.SetHashPassword(customerUserModel.Password, GetConfig());
                customerUserModel.Avatar = (customerUserModel.Avatar == null) ? "" : customerUserModel.Avatar;
                bool check = await aCustomerRep.UpdateCustomerUser(customerUserModel);
                if (check)
                {
                    CustomerModel customerModel = new CustomerModel();
                    customerModel.UserName = customerUserModel.UserName;
                    customerModel.PassWord = customerUserModel.Password;
                    var customer = await this.aCustomerRep.SignIn(customerModel);
                    if (CreateCookie(customer))
                        return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// create cookie
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private bool CreateCookie(CustomerUserModel customer)
        {
            try
            {
                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                serializeModel.UserId = customer.Id;
                serializeModel.FirstName = customer.UserName;
                serializeModel.Avatar = customer.Avatar;
                string userData = JsonConvert.SerializeObject(serializeModel);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                customer.Email,
                DateTime.Now,
                DateTime.Now.AddDays(1),
                false, //pass here true, if you want to implement remember me functionality
                userData);

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie("App_AuthenProject", encTicket);
                Response.Cookies.Add(faCookie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// check email, username and phone
        /// </summary>
        /// <param name="customerUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckEmailUserPhone(CustomerUser customerUserModel)
        {
            int check = await aCustomerRep.CheckEmailUserPhone(customerUserModel);
            return Json(check,JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("App_AuthenProject"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["App_AuthenProject"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Home");
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "none")]
        private string GetConfig()
        {
            return WebConfigurationManager.AppSettings["Authen"];
        }

        private string html()
        {

            string s = @"<p>test nha ox <span style='color:red'>js cscc </span></p>";
            return s;
        }
    }
}