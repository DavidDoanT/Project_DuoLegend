using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoAPI.Models;

namespace DemoAPI.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            conn.ConnectionString = "data source=SK-20190915MKOH; database=test; integrated security = SSPI;";
        }[HttpPost]
        public ActionResult checkLogin(user account)
        {
            connectionString();
            conn.Open();
            com.Connection = conn;
            com.CommandText = "select * from userAccount where username = '"+account.username+"' and password = '"+account.password+"' "; ;
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                return View("mainpage");
            }
            else
            {
                conn.Close();
                return View("error");
            }
            

        }
    }
}