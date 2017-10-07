using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using System.Data;

namespace Logic
{
    public  class ShopGoods
    {

        public void Top5Goods()
        {
            
            SqlConnection connection = new SqlConnection(new Connection().getConnectionString());
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Preke, Tipas, Kaina, COUNT(*) Kiekis " +
                "FROM dbo.Prekes GROUP BY Preke ORDER BY DESC LIMIT 5";
        }
    }
}
