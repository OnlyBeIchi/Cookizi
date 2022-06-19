using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cookizi.Models
{
    public class QLFood
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào tên thức ăn")]
        [Display(Name = "Tên thức ăn")]
        public string TenFood { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào nguyên liệu")]
        [Display(Name = "Nguyên Liệu")]
        public string NguyenLieu { set; get; }
        public int Calories { set; get; }
       
        [Required(ErrorMessage = "Bạn cần nhập vào công thức nấu ăn")]
        [Display(Name = "Công thức nấu ăn")]
        public string Congthucnauan { set; get; }
    }

    class FoodList
    {
        DBConnection db;
        public FoodList()
        {
            db = new DBConnection();
        }

        public List<QLFood> GetFood(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "Select * From Food";
            }
            else
            {
                sql = "Select * From Food Where Id = " + ID;
            }

            List<QLFood> strList = new List<QLFood>();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            // Mở kết nối
            con.Open();
            cmd.Fill(dt);
            // Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLFood strFood;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFood = new QLFood();
                strFood.ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                strFood.TenFood = dt.Rows[i]["TenFood"].ToString();
                strFood.NguyenLieu = dt.Rows[i]["NguyenLieu"].ToString();
                strFood.Congthucnauan = dt.Rows[i]["Congthucnauan"].ToString();
                strFood.Calories =int.Parse(dt.Rows[i]["Calories"].ToString());
                strList.Add(strFood);
            }
            return strList;

        }
        // Thêm dữ liệu
        public void AddFood(QLFood strFood)
        {
            string sql = "INSERT INTO Food(TenFood, NguyenLieu,Calories,Congthucnauan)VALUES(N'" +strFood.TenFood+ "', N'" + strFood.NguyenLieu + "', N'" + strFood.Congthucnauan + "', N'" + strFood.Calories +"')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }

        // Sửa dữ liệu
        public void EditFood(QLFood strFood)
        {
            string sql = "UPDATE Food SET TenFood = N'" + strFood.TenFood + "',NguyenLieu =  N'" + strFood.NguyenLieu + "', N'" + strFood.Congthucnauan + "' WHERE Id =" + strFood.ID;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }

        // Xóa dữ liệu
        public void DeleteFood(QLFood strFood)
        {
            string sql = "DELETE FROM Food WHERE Id = " + strFood.ID;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
    }
}