using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cookizi.Models
{
    public class DBConnection
    {
        string strCon;

        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["FoodDBConnectionString"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}