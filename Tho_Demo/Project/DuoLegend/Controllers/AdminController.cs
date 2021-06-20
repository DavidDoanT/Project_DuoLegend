using DuoLegend.DAO;
using Microsoft.AspNetCore.Mvc;

namespace DuoLegend.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string adminPassword)
        {
            bool isLoginAllowed = AdminLoginDAO.Login(email, adminPassword);

            //If email exist and has a corresponding password with inputted password,
            //login succeed and redirect to main page
            if(isLoginAllowed){
                return View("Main");   
            }

            ViewBag.loginFailed = true;

            return View();
        }

    }
}
