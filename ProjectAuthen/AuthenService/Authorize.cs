using Newtonsoft.Json;
using ProjectModelCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace ProjectAuthen.AuthenService
{
    //public class Authorize : AuthorizeAttribute
    //{
    //    protected override bool AuthorizeCore(HttpContextBase httpContext)
    //    {
    //        string access_token = (httpContext.Request.Cookies["App_AuthenProject"] != null) ? httpContext.Request.Cookies["App_AuthenProject"].Value : null;
    //        if (!string.IsNullOrWhiteSpace(access_token))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        if (!AuthorizeCore(filterContext.HttpContext))
    //        {
    //            filterContext.Result = new RedirectToRouteResult(
    //                    new RouteValueDictionary(
    //                        new
    //                        {
    //                            controller = "Home",
    //                            action = "Index",
    //                            returnUrl = filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped)
    //                        }));
    //        }
    //    }
    //}
    public class AuthoriAccessAction : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string access_token = (httpContext.Request.Cookies["App_AuthenProject"] != null) ? httpContext.Request.Cookies["App_AuthenProject"].Value : null;
            if (!string.IsNullOrWhiteSpace(access_token))//&& CheckRole(access_token))
            {
                return true;
            }
            return false;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                area = "",
                                controller = "Home",
                                action = "Index",
                                returnUrl = filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped)
                            }));
            }
        }
        public bool CheckRole(string access_token)
        {
            try
            {
                if (access_token != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(access_token);
                    CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                    //if (serializeModel.roles == (int)Role.Admin || serializeModel.roles == (int)Role.Manager)
                    //{
                        return true;
                    //}
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
    public class AuthoriAdminAction : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string access_token = (httpContext.Request.Cookies["App_AuthenProject"] != null) ? httpContext.Request.Cookies["App_AuthenProject"].Value : null;
            if (!string.IsNullOrWhiteSpace(access_token) && CheckRole(access_token))
            {
                return true;
            }
            return false;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Home",
                                action = "Index",
                                returnUrl = filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped)
                            }));
            }
        }
        public bool CheckRole(string access_token)
        {
            try
            {
                if (access_token != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(access_token);
                    CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                    //if (serializeModel.roles == (int)Role.Admin || serializeModel.roles == (int)Role.Manager)
                    //{
                    //    return true;
                    //}
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}