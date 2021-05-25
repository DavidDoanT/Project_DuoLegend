
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DuoLegend.Models;
namespace DuoLegend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            conn.ConnectionString = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.2;Integrated Security=True";
            conn.Open();
            com.CommandText = "Select inGameName from User LIMIT 3";
            dr = com.ExecuteReader();
            dr.Read();
            string test = (string)dr[$"inGameName"];
            Test t = new Test();
            t.inGameName = test;

            conn.Close();
            //connection.Open();
            //connection.Close();
            //Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.2;Integrated Security=True
            return View(t);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
