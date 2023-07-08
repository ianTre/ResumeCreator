using Microsoft.AspNetCore.Mvc;
using ResumeCreator.Manager;
using ResumeCreator.Models;

namespace ResumeCreator.Controllers
{
    public class EducationController : Controller
    {

        private EducationManager _Manager;

        public EducationController()
        {
            _Manager = new EducationManager();    

        }

        public IActionResult Index()
        {
            List<Education> list = _Manager.GetAll();

            return View(list);
        }

        [ HttpGet]

        public IActionResult New()
        {
            int userId = 1;
            Education education = new Education(userId);

            return View(education);  
        }

        [HttpPost]

        public  IActionResult New(Education education)
        {
            // Acá faltan validaciones de todos los campos ingresados x el pelotudo

            try
            {
                _Manager.Save(education);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return RedirectToAction("index");
            }
            

        }



    }
}
