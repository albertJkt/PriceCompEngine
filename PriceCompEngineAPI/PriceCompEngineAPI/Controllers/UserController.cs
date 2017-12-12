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
        

        /// <summary>
        /// Get the specified user.
        /// </summary>
        /// <returns>User object if user tries to login and it's successful
        /// Null - if user doesn't exist or username (and/or email) is taken
        /// User object with password 1 if username and email is not taken</returns>
        public User Get([FromUri] User user)
        {
            if (string.IsNullOrEmpty(user.Email))
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
                    return useris;
                }
            }
        }
    }
}