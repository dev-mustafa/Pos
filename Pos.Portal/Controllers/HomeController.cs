using System;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Domain.Infrastructure;

namespace POS.Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //CookieHelper.TenantId = 4;
            return View();          
        }

      
        [AllowAnonymous]
        public void ToggleLanguage()
        {
            //Response.Cookies.Remove("Culture");
            //Response.Cookies.Add(System.Threading.Thread.CurrentThread.CurrentUICulture.Name.StartsWith("ar")
            //    ? new HttpCookie("Culture") {Expires = DateTime.Now.AddDays(360), Value = "en-US"}
            //    : new HttpCookie("Culture") {Expires = DateTime.Now.AddDays(360), Value = "ar-EG"});
        }
    }
}