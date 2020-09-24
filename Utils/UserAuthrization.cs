using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GameTournament.Utils
{


    public class UserAuthrization 
    { }

        public class CustomAuthrization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthUser.isAdminLogIn())
            {
                filterContext.Result = new RedirectToRouteResult(

                    new RouteValueDictionary
                                       {
                                       { "action", "Error" },
                                       { "controller", "Home" }
                                       }

                    );
                filterContext.HttpContext.Response.StatusCode = 404;
            }

        }

    }


    public class CustomAuthrizationRedirect : AuthorizeAttribute
    {
        private string Action;
        private string Controller;
        public CustomAuthrizationRedirect(string action, string controller)
        {
            this.Action = action;
            this.Controller = controller;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthUser.isAdminLogIn())
            {
                filterContext.Result = new RedirectToRouteResult(

                    new RouteValueDictionary
                                       {
                                       { "action", this.Action },
                                       { "controller", this.Controller }
                                       }

                    );
            }

        }

    }
}