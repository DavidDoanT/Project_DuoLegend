using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sprint1.Controllers;
using Sprint1.Models;
using System.Data.SqlClient;



namespace Sprint1.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            conn.ConnectionString = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.2;Integrated Security=True";
        }
        [HttpPost]
        public IActionResult Login(UserInfo acc)
        {
            connectionString();
            conn.Open();
            com.Connection = conn;
            com.CommandText = "select * from userAccount where username = '" + acc.username + "' and password = '" + acc.password + "' "; ;
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                return View("Index1");
            }
            else
            {
                conn.Close();
                return View("Index2");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
