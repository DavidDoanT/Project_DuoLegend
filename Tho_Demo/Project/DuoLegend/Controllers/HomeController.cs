
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
            conn.ConnectionString = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.2;Integrated Security=True";
            conn.Open();
            conn.Close();
            //connection.Open();
            //connection.Close();
            //Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.2;Integrated Security=True
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
