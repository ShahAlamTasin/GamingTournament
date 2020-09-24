using GameTournament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameTournament.Utils
{
    public class AuthUser
    {

        private static string AUTH_ADMIN_COOKIE_NAME = "AdminUserId";
        private static string AUTH_ADMIN_COOKIE_TYPE = "TYPE_USER";
        private static DatabaseContext db = AppDatabase.getInstence().getDatabase();

        
        public static HttpCookie setGamerInCookie(string userId)
        {
            HttpCookie AdminLoginCookie = new HttpCookie(AUTH_ADMIN_COOKIE_NAME);
            AdminLoginCookie.Value = userId;
            AdminLoginCookie.Expires = DateTime.Now.AddDays(30);
            AdminLoginCookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(AdminLoginCookie);

            HttpCookie AdminLoginCookie2 = new HttpCookie(AUTH_ADMIN_COOKIE_TYPE);
            AdminLoginCookie2.Value = "gamer";
            AdminLoginCookie2.Expires = DateTime.Now.AddDays(30);
            AdminLoginCookie2.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(AdminLoginCookie2);
            return AdminLoginCookie;
        }


        public static HttpCookie setOrganizerInCookie(string userId)
        {
            HttpCookie AdminLoginCookie = new HttpCookie(AUTH_ADMIN_COOKIE_NAME);
            AdminLoginCookie.Value = userId;
            AdminLoginCookie.Expires = DateTime.Now.AddDays(30);
            AdminLoginCookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(AdminLoginCookie);

            HttpCookie AdminLoginCookie2 = new HttpCookie(AUTH_ADMIN_COOKIE_TYPE);
            AdminLoginCookie2.Value = "organizer";
            AdminLoginCookie2.Expires = DateTime.Now.AddDays(30);
            AdminLoginCookie2.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(AdminLoginCookie2);
            return AdminLoginCookie;
        }




        public static Gamer getGamerUser()
        {
            var userId = HttpContext.Current.Request.Cookies.Get(AUTH_ADMIN_COOKIE_NAME);
            var userType = HttpContext.Current.Request.Cookies.Get(AUTH_ADMIN_COOKIE_TYPE);
            int id = Convert.ToInt32(userId.Value);
            Gamer adminUsers = db.Gamers.Find(id);
            return adminUsers;
        }

        public static Organizer getOrganizerUser()
        {
            var userId = HttpContext.Current.Request.Cookies.Get(AUTH_ADMIN_COOKIE_NAME);
            var userType = HttpContext.Current.Request.Cookies.Get(AUTH_ADMIN_COOKIE_TYPE);
            int id = Convert.ToInt32(userId.Value);
            Organizer adminUsers = db.Organizer.Find(id);
            return adminUsers;
        }


        public static HttpCookie getUserType()
        {
            HttpCookie userType = HttpContext.Current.Request.Cookies.Get(AUTH_ADMIN_COOKIE_TYPE);
            System.Diagnostics.Debug.WriteLine(userType.Value);
            return userType;
        }


        public static HttpCookie signOutAdminUser()
        {
            HttpCookie AdminLoginCookie = new HttpCookie(AUTH_ADMIN_COOKIE_NAME);
            AdminLoginCookie.Value = "";
            AdminLoginCookie.Expires = DateTime.Now.AddDays(-1);
            AdminLoginCookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(AdminLoginCookie);

            AdminLoginCookie = new HttpCookie(AUTH_ADMIN_COOKIE_TYPE);
            AdminLoginCookie.Value = "";
            AdminLoginCookie.Expires = DateTime.Now.AddDays(-1);
            AdminLoginCookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(AdminLoginCookie);
            return AdminLoginCookie;
        }
        public static bool isAdminLogIn()
        {
            HttpCookie userId = HttpContext.Current.Request.Cookies.Get(AUTH_ADMIN_COOKIE_NAME);
            //System.Diagnostics.Debug.WriteLine(userId.ToString());
            if (userId != null)
                return true;
            else
                return false;
        }
    }
}