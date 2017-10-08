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
            SqlDataReader dr;
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Preke, Tipas, Kaina, COUNT(*) Kiekis " +
                "FROM dbo.Prekes GROUP BY Preke ORDER BY 4 DESC LIMIT 5";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
               //cia bus perduodamos eilutes reiksmes 1 stulp 1 eil, 2 stulp 2 eil, ... n stulp 1 eil,
               //1 stulp 2 eil...
            }

        }
    }
}
