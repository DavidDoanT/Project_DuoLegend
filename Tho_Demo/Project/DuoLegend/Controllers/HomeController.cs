
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DuoLegend.ViewModels;

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
            conn.ConnectionString = "Data Source=DESKTOP-B97EA2J;Initial Catalog=no_data_DuoDatabase_version-1.0.2;Integrated Security=True";
            
            conn.Open();
            com.Connection = conn;
            com.CommandText = "select top(2) * from  testUser";
            SqlDataReader reader = com.ExecuteReader();
            MainPageViewModel test = new MainPageViewModel();
            int count = 0;
            while(reader.Read())
            {
                
                test.inGameName[count] = (string)reader["inGameName"];
                count++;
            }

            conn.Close();
            //connection.Open();
            //connection.Close();
            //Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.2;Integrated Security=True
            return View(test);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
