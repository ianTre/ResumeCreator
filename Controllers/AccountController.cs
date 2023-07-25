using Microsoft.AspNetCore.Mvc;
using ResumeCreator.Manager;
using ResumeCreator.Models;

namespace ResumeCreator.Controllers
{
    public class AccountController : Controller
    {
        private AccountManager _Manager;

        public AccountController()
        {
            _Manager = new AccountManager();

        }

        [HttpGet]
        public IActionResult New()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult New(User user)
        {
                

            _Manager.Add(user);

            //Retornar a la vista de listado
            return RedirectToAction("ProfileDataList","ProfileData");
        }


    }
}
