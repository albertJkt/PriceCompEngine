using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DataBase;
using System.Web.Mvc;

namespace PriceCompEngineAPI.Controllers
{
    public class UserController : ApiController
    {
        public void Post([FromBody] User newUser)
        {
            DBController db = new DBController();
            db.InsertUser(newUser);
        }
        
        public User Get([FromUri] string username,[FromUri] string password, [FromUri] string email )
        {
            User user = new User();
            user.Email = email;
            user.UserName = username;
            user.Password = password;
            if (string.IsNullOrEmpty(user.Email) || user.Email=="null")
            {
                DBController db = new DBController();
                User usr = db.GetUser(user.UserName, user.Password);
                if (usr != null)
                {
                    return usr;
                }
                else return null;
            }
            else
            {
                DBController db = new DBController();
                bool Exists = db.CheckIfExists(user.UserName, user.Email);
                if (Exists)
                {
                    return null;
                }
                else
                {
                    User useris = new User();
                    useris.Password = "1";
                    useris.UserName = "x";
                    return useris;
                }
            }
    }
}
