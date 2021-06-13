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

            if(isLoginAllowed){
                return View("Main");   //AdminMain not yet implemented
            }

            return View();
        }

    }
}
