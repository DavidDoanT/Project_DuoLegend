using DuoLegend.DAO;
using DuoLegend.Models;
using DuoLegend.DAO.AdminDAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DuoLegend.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// Go to Login view
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Log the admin in through email and password
        /// If email and password is valid, set the session for the admin and redirect them to the admin's main page
        /// If not, return to login page with error message.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="adminPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string email, string adminPassword)
        {
            bool isLoginAllowed = AdminLoginDAO.Login(email, adminPassword);

            //If email exist and has a corresponding password with inputted password,
            //login succeed and redirect to main page
            if(isLoginAllowed){
                HttpContext.Session.SetInt32(SessionKeys.Keys.AdminId, AdminInfoDAO.GetAdminId(email));
                return RedirectToAction("Main");   
            }

            ViewBag.loginFailed = true;

            return View();
        }

        public IActionResult Main()
        {   
            IList<WebsiteStatistics> webStatList = WebsiteStatisticsDAO.GetRecords(30);
            IList<DataPoint> uniqueVisitorDataPoints = new List<DataPoint>();
            IList<DataPoint> siteVisitorDataPoitns = new List<DataPoint>();
            IList<DataPoint> newAccountDataPoints = new List<DataPoint>();
            DataPoint dp;

            //Create datapoints
            foreach(WebsiteStatistics webStat in webStatList)
            {
                //Create datapoints containing data about UniqueVisitor
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.UniqueVisitor);
                uniqueVisitorDataPoints.Add(dp);
                //Create datapoints containing data about siteVisit
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.SiteVisit);
                siteVisitorDataPoitns.Add(dp);
                //Create datapoints containing data about newAccount numbers 
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.NewAccount);
                newAccountDataPoints.Add(dp);
            }

            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;

            ViewBag.UniqueVisitorData = JsonConvert.SerializeObject(uniqueVisitorDataPoints, jsonSetting);
            ViewBag.SiteVisitData = JsonConvert.SerializeObject(siteVisitorDataPoitns, jsonSetting);
            ViewBag.NewAccountData = JsonConvert.SerializeObject(newAccountDataPoints, jsonSetting);

            return View();
        }

        public IActionResult UserList()
        {
            IEnumerable<User> userList = DAO.UserDAO.getAllUser();
            return View(userList);
        }

        public IActionResult BanUser(int id)
        {
            ViewBag.userId = id;
            return View();
        }
        /// <summary>
        /// Log the admin out
        /// Clears all session
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        //Go to website statistic page
        public IActionResult WebsiteStatistic()
        {
            IList<WebsiteStatistics> webStatList = WebsiteStatisticsDAO.GetRecords();
            IList<DataPoint> uniqueVisitorDataPoints = new List<DataPoint>();
            IList<DataPoint> siteVisitorDataPoitns = new List<DataPoint>();
            IList<DataPoint> newAccountDataPoints = new List<DataPoint>();
            DataPoint dp;

            //Create datapoints
            foreach(WebsiteStatistics webStat in webStatList)
            {
                //Create datapoints containing data about UniqueVisitor
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.UniqueVisitor);
                uniqueVisitorDataPoints.Add(dp);
                //Create datapoints containing data about siteVisit
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.SiteVisit);
                siteVisitorDataPoitns.Add(dp);
                //Create datapoints containing data about newAccount numbers 
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.NewAccount);
                newAccountDataPoints.Add(dp);
            }

            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;

            ViewBag.UniqueVisitorData = JsonConvert.SerializeObject(uniqueVisitorDataPoints, jsonSetting);
            ViewBag.SiteVisitData = JsonConvert.SerializeObject(siteVisitorDataPoitns, jsonSetting);
            ViewBag.NewAccountData = JsonConvert.SerializeObject(newAccountDataPoints, jsonSetting);


            return View();
        }
    }
}
