using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
  public  class Connection
    {
        private const string ConnectionString = "Server=tcp:pricecompengn.database.windows.net,1433;Initial Catalog=PriceCompEngine;Persist Security Info=False;User ID=adminlogin33;Password=Adminpassword33;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}
