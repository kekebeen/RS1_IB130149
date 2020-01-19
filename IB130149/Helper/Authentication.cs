using IB130149.Models;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using IB130149.Context;


namespace IB130149.Helper
{
    public static class Authentication
    {
        private const string loggedInUser = "logged_in_user";


        public static void SetLoggedUser(this HttpContext context, User user, bool rememberMe=false)
        {
            MyContext db = context.RequestServices.GetService<MyContext>();
            string oldToken = context.Request.GetCookieJson<string>(loggedInUser);
            
            if(oldToken != null)
            {
                AuthorizationToken toDelete = db.AuthorizationToken.FirstOrDefault(x => x.Value == oldToken);
                
                if(toDelete != null)
                {
                    db.SaveChanges();
                }
            }

            if(user != null)
            {
                string token = Guid.NewGuid().ToString();
                db.AuthorizationToken.Add(new AuthorizationToken
                {
                    Value = token,
                    UserId = user.Id
                });
                db.SaveChanges();
                context.Response.SetCookieJson(loggedInUser, token);
            }
        }
    
        public static string GetCurrentToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(loggedInUser);
        }

        public static User GetLoggedInuser(this HttpContext context)
        {
            MyContext db = context.RequestServices.GetService<MyContext>();

            string token = context.Request.GetCookieJson<string>(loggedInUser);

            if(token == null)
            {
                return null;
            }

            return db.AuthorizationToken
                .Where(x => x.Value == token)
                .Select(s => new User { 
                    Name = s.User.Name,
                    Surname = s.User.Surname,
                    Username = s.User.Username,
                    Email = s.User.Email,
                    Password = s.User.Password,
                    Address = s.User.Address,
                    Telephone = s.User.Telephone,
                    Employee = db.Employee.Where(x => x.UserId == s.UserId).ToList()
                })
                .SingleOrDefault();
        }

        public static void Logout(this HttpContext context)
        {
            MyContext db = context.RequestServices.GetService<MyContext>();
            string token = context.Request.GetCookieJson<string>(loggedInUser);

            AuthorizationToken current = db.AuthorizationToken.Where(x => x.Value == token).SingleOrDefault();
            if(current != null)
            {
                db.AuthorizationToken.Remove(current);
                db.SaveChanges();
            }
        }
    }
}
 