using DuoLegend.DAO;
using Microsoft.AspNetCore.Mvc;

namespace DuoLegend.Controllers
{
    class AdminController : Controller 
    {
        //Directs to Login page
        public IActionResult Login()
        {
            return View();
        }

        //Handles admin Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            bool isLoginAllowed = AdminLoginDAO.Login(email, password);

            if(isLoginAllowed){
                return View("AdminMain");   //AdminMain not yet implemented
            }

            return View();
        }
    }
}