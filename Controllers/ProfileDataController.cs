using ComprobadorDeMail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.CodeAnalysis.Editing;
using ResumeCreator.Manager;
using ResumeCreator.Models;

namespace ResumeCreator.Controllers
{

    [Route("/DatosPersonales")]
    public class ProfileDataController : Controller //Los controllers tienen 2 responsabilidades :
                                                    //Setear info necesaria para mostrar una view. 
                                                    //Recibir info que envia una View
    {
        private ProfileDataManager _Manager;

        public ProfileDataController()
        {
            _Manager = new ProfileDataManager();
        }

        [HttpGet]
        [Route("/")]
        [Route("List")]
        public IActionResult ProfileDataList()
        {
            var PDList = _Manager.GetProfileData();
            return View(PDList);
        }

        //Devuelve una vista para Crear nuevo Perfil
        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            ProfileData model = new ProfileData();
            return View("Nuevo",model);
        }

        //Recibe datos para crear nuevo Perfil y guardalo en la Base de datos
        [HttpPost]
        [Route("New")]
        public IActionResult New(ProfileData ProfileData)
        {
            bool valid = true;
            //Validar datos recibidos
            if (string.IsNullOrEmpty(ProfileData.UserName))
            {
                ModelState.AddModelError("NombreUsuario", "El nombre de usuario no es correcto");

            }

            if (!IsValidMail(ProfileData.Email))
            {
                ModelState.AddModelError("Email", "El mail ingresado no corresponde al formato de mail");
                valid = false;
            }

            if (!IsDniValid(ProfileData.DNI))
            {
                ModelState.AddModelError("Documento", "El numero de docuemento no es correcto");
                valid = false;
            }
            if (!valid)
            {
                return View(ProfileData);
            }

            //IF todo bien       

            _Manager.Save(ProfileData);

            //Retornar a la vista de listado
            return RedirectToAction("UserList");
        }

        private bool IsDniValid(string dni)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(dni))
            {
                valid = false;
            }

            int dniNumber;
            if (!int.TryParse(dni, out dniNumber))
            {
                foreach (char character in dni)
                {
                    if (character == '.')
                        dni = dni.Remove(dni.IndexOf(character), 1);
                }
                if (!int.TryParse(dni, out dniNumber))
                    valid = false;
            }
            return valid;
        }
        // TODO LLEGAMOS HASTA ACÁ CON LA TRADUCCIÓN, HAY QUE CONTINUAR DENTRO DE MAILVALIDATOR
        private bool IsValidMail(string email)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            CompDeMail comprobador = new CompDeMail(email);
            comprobador.ComprobDeMail();
            valid = comprobador.esMail;
            return valid;
        }


    }
}
