using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRANSPORTATIONMANAGEMENTSYSTEM.Filters
{
   
        public class AuthenticationFilter : ActionFilterAttribute
        {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            if (controller != "Account" || action != "signin")
            {
                if (filterContext.HttpContext.Session["IsAuthenticated"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Account/Signin");
                }
                base.OnActionExecuting(filterContext);
               
            }
        }

        }
    }