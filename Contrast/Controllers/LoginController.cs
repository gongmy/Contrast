using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;

namespace CustomTab1.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(string url, string error)
        {
            ViewBag.Url = url;
            return View();
        }

        public ActionResult login(int id, string url)
        {
            SessionLoginUser sessionLoginUser = new SessionLoginUser();
            Contrast_AccountModel model = new Contrast_AccountModel();
            string loginName = null;
            string password = null;
            bool isError = false;
            switch (id)
            {
                case 1:
                    loginName = "admin1";
                    password = "password";
                    break;

                case 2:
                    loginName = "admin2";
                    password = "password";
                    break;

                case 3:
                    loginName = "admin3";
                    password = "password";
                    break;

                case 4:
                    loginName = "admin4";
                    password = "password";
                    break;

                case 5:
                    loginName = "admin5";
                    password = "password";
                    break;

                default:
                    isError = true;
                    break;
            }
            if (!isError)
            {
                var user = model.Login(loginName, password);
                if (user != null)
                {
                    sessionLoginUser.Contrast_Account = user;
                    Session["SessionLoginUser"] = sessionLoginUser;
                }
                else
                {
                    isError = true;
                }
            }
            if (isError)
            {
                return View("Index", new { error = "账号错误。" });
            }
            else
            {
                if (url != null && url.Length > 0)
                {
                    return Redirect(url);
                }
                else
                {
                    return RedirectToAction("Index", "Contrast_UserInfo");
                }
            }
        }

    }
}
