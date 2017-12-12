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
        
        public List<User> Get ()
        {
            DBController db = new DBController();
            List<User> users = db.GetUsers();
            return users;
        }
    }
}