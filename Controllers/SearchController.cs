using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookizi.Models;

namespace Cookizi.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string search)
        {
            string con = ConfigurationManager.ConnectionStrings["FoodDBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sql = "SELECT * FROM [dbo].[Food] WHERE TenFood like N'%" + search + "%' OR NguyenLieu like N'%" + search + "%' ";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<QLFood> strList = new List<QLFood>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strList.Add(new QLFood
                {
                    TenFood = Convert.ToString(dr["TenFood"]),
                    NguyenLieu = Convert.ToString(dr["NguyenLieu"]),
                    
                });
            }
            sqlcon.Close();
            ModelState.Clear();
            return View(strList);
        }
    }
}