using Microsoft.AspNetCore.Mvc;
using ResumeCreator.Manager;
using ResumeCreator.Models;

namespace ResumeCreator.Controllers
{
    public class DatosPersonalesController : Controller
    {
        [HttpGet]
        public IActionResult Localizaciones()
        {
            LocalizacionManager localizacionManager = new LocalizacionManager();
            List<Pais> paises = localizacionManager.ObtenerListadoLocalizaciones();
            return View(paises);
        }

        [HttpGet]
        public IActionResult Listado()
        {
            DatosPersonalesManager DpManager = new DatosPersonalesManager();
            var listaDP = DpManager.ObtenerDatosPersonales();
            return View(listaDP);
        }

        //Devuelve una vista para Crear nuevo Perfil
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        //Recibe datos para crear nuevo Perfil y guardalo en la Base de datos
        [HttpPost]
        public void Nuevo(string NombreDeUsuario, string Email, string Documento)
        {
            Console.WriteLine("Recibi los datos :" + NombreDeUsuario + Email + Documento);
            //Validar datos recibidos

            //IF todo bien 

            //Guardar datos en la BD

            //ELSE

            //return View("Nuevo"); 


            //Retornar a la vista de listado
            //return View("Listado");
        }

    }
}
