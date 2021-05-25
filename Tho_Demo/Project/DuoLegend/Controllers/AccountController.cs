using DuoLegend.GlobalConfig;
using DuoLegend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Controllers
{

    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginInfor acc)
        {
            //connectionString();
            //conn.Open();
            //com.Connection = conn;
            //com.CommandText = "select * from userAccount where username = '" + acc.username + "' and password = '" + acc.password + "' "; ;
            //dr = com.ExecuteReader();
            //if (dr.Read())
            //{
            //    conn.Close();
            //    return View("Index1");
            //}
            //else
            //{
            //    conn.Close();
            return View("Index2");
            //}
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

