using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRANSPORTATIONMANAGEMENTSYSTEM.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
    
        public ActionResult Signin(string username, string password)
        {
            // Hardcoded username and password
            const string hardcodedUsername = "admin";
            const string hardcodedPassword = "@admin@123#";

            if (username == hardcodedUsername && password == hardcodedPassword)
            {
                // If the credentials match, create a session for the user
                Session["IsAuthenticated"] = true;

                // Redirect to the Home page or any other page
                return RedirectToAction("Index", "Home");
            }

            // If the login fails, show an error message
            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public ActionResult Logout()
        {
            Session["IsAuthenticated"] = null;
            return RedirectToAction("Signin", "Account");
        }
    }
}