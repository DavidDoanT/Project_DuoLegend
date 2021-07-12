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
            if (isLoginAllowed)
            {
                HttpContext.Session.SetInt32(SessionKeys.Keys.AdminId, AdminInfoDAO.GetAdminId(email));
                return RedirectToAction("Main");
            }

            ViewBag.loginFailed = true;

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
            IList<WebsiteStatistics> weeklyWebStatList = WebsiteStatisticsDAO.GetRecordsWeekly();
            IList<WebsiteStatistics> monthlyWebStatList = WebsiteStatisticsDAO.GetRecordsMonthly();

            //Please tell me if there's better code. I'm too tired to research SignalR real time data transmission
            //God help me
            IList<DataPoint>[] arrayOfDataList = CreateDataPointLists(webStatList);
            IList<DataPoint>[] arrayOfDataListWeekly = CreateDataPointLists(weeklyWebStatList);
            IList<DataPoint>[] arrayOfDataListMonthly = CreateDataPointLists(monthlyWebStatList);

            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;

            //Daily data
            ViewBag.UniqueVisitorData = JsonConvert.SerializeObject(arrayOfDataList[0], jsonSetting);
            ViewBag.SiteVisitData = JsonConvert.SerializeObject(arrayOfDataList[1], jsonSetting);
            ViewBag.NewAccountData = JsonConvert.SerializeObject(arrayOfDataList[2], jsonSetting);

            //Weekly data
            ViewBag.UniqueVisitorDataWeekly = JsonConvert.SerializeObject(arrayOfDataListWeekly[0], jsonSetting);
            ViewBag.SiteVisitDataWeekly = JsonConvert.SerializeObject(arrayOfDataListWeekly[1], jsonSetting);
            ViewBag.NewAccountDataWeekly = JsonConvert.SerializeObject(arrayOfDataListWeekly[2], jsonSetting);

            //Monthly data
            ViewBag.UniqueVisitorDataMonthly = JsonConvert.SerializeObject(arrayOfDataListMonthly[0], jsonSetting);
            ViewBag.SiteVisitDataMonthly = JsonConvert.SerializeObject(arrayOfDataListMonthly[1], jsonSetting);
            ViewBag.NewAccountDataMonthly = JsonConvert.SerializeObject(arrayOfDataListMonthly[2], jsonSetting);

            return View();
        }

        /// <summary>
        /// Creates an array of lists containing data points from a list of website statistics
        /// </summary>
        /// <param name="webStatList">A list containing records of website statistics</param>
        /// <returns>
        /// An array of lists containing data points
        /// Index 0 stores UniqueVisitor datapoint
        /// Index 1 stores SiteVisit datapoint
        /// Index 2 stores NewAccount datapoint
        /// </returns>
        private IList<DataPoint>[] CreateDataPointLists(IList<WebsiteStatistics> webStatList)
        {
            //Create an array of Data List
            IList<DataPoint>[] arrayOfDataList = new IList<DataPoint>[3];
            //Initialize the Lists
            arrayOfDataList[0] = new List<DataPoint>();
            arrayOfDataList[1] = new List<DataPoint>();
            arrayOfDataList[2] = new List<DataPoint>();

            DataPoint dp;
            foreach(WebsiteStatistics webStat in webStatList)
            {
                //Creates a uniqueVisitor data point and add it to the List
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.UniqueVisitor);
                arrayOfDataList[0].Add(dp);

                //Creates a siteVisit data point and add it to the list
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.SiteVisit);
                arrayOfDataList[1].Add(dp);

                //Creates a newAccount data point and add it to the list
                dp = new DataPoint(webStat.Date.ToString("dd/MM"), webStat.NewAccount);
                arrayOfDataList[2].Add(dp);
            }

            return arrayOfDataList;
        }
    }
}
