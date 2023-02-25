using ComprobadorDeMail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.CodeAnalysis.Editing;
using ResumeCreator.Manager;
using ResumeCreator.Models;

namespace ResumeCreator.Controllers
{
    public class DatosPersonalesController : Controller
    {
        private DatosPersonalesManager manager;
        private LocalizacionManager localizacionManager;

        public DatosPersonalesController()
        {
            manager = new DatosPersonalesManager();
            localizacionManager = new LocalizacionManager();
        }


        [HttpGet]
        public IActionResult Localizaciones()
        {
            List<Pais> paises = localizacionManager.ObtenerListadoLocalizaciones();
            return View(paises);
        }

        [HttpGet]
        public IActionResult Listado()
        {
            //manager = new DatosPersonalesManager();
            var listaDP = manager.ObtenerDatosPersonales();
            return View(listaDP);
        }

        //Devuelve una vista para Crear nuevo Perfil
        [HttpGet]
        public IActionResult Nuevo()
        {
            DatosPersonales model = new DatosPersonales();
            return View(model);
        }

        //Recibe datos para crear nuevo Perfil y guardalo en la Base de datos
        [HttpPost]
        public IActionResult Nuevo(DatosPersonales datosPersonales)
        {
            bool valido = true;
            //Validar datos recibidos
            if (string.IsNullOrEmpty(datosPersonales.NombreUsuario))
            {
                ModelState.AddModelError("NombreUsuario", "El nombre de usuario no es correcto");

            }

            if (!EsMailValido(datosPersonales.Email))
            {
                ModelState.AddModelError("Email", "El mail ingresado no corresponde al formato de mail");
                valido = false;
            }

            if (!EsDocumentoValido(datosPersonales.Documento))
            {
                ModelState.AddModelError("Documento", "El numero de docuemento no es correcto");
                valido = false;
            }
            if (!valido)
            {
                return View(datosPersonales);
            }

            //IF todo bien       

            manager.GuardarDatos(datosPersonales);

            //Retornar a la vista de listado
            return RedirectToAction("Listado");
        }

        private bool EsDocumentoValido(string documento)
        {
            bool valido = true;
            if (string.IsNullOrEmpty(documento))
            {
                valido = false;
            }

            int numeroDoc;
            if (!int.TryParse(documento, out numeroDoc))
            {
                foreach (char caracter in documento)
                {
                    if (caracter == '.')
                        documento = documento.Remove(documento.IndexOf(caracter), 1);
                }
                if (!int.TryParse(documento, out numeroDoc))
                    valido = false;
            }
            return valido;
        }

        private bool EsMailValido(string email)
        {
            bool valido = true;
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            CompDeMail comprobador = new CompDeMail(email);
            comprobador.ComprobDeMail();
            valido = comprobador.esMail;
            return valido;
        }


    }
}
