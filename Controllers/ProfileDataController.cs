using ComprobadorDeMail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.CodeAnalysis.Editing;
using ResumeCreator.Manager;
using ResumeCreator.Models;
using System;

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
        [Route("List")] //TODO : add UserId from the user logged . We should NOT see all the user , only the logged account and the secondary accounts created by them. 
        public IActionResult ProfileDataList()
        {
            var PDList = _Manager.GetAllProfileData();
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
        public IActionResult New(ProfileData profileData)
        {
            bool valid = true;
            profileData.IsMainProfile = false; //In this Controller we are creating secondary accounts or profiles. 
            //Validar datos recibidos
            if (string.IsNullOrEmpty(profileData.UserName))
            {
                ModelState.AddModelError("NombreUsuario", "El nombre de usuario no es correcto");

            }

            if (!IsValidMail(profileData.Email))
            {
                ModelState.AddModelError("Email", "El mail ingresado no corresponde al formato de mail");
                valid = false;
            }

            if (!IsDniValid(profileData.DNI))
            {
                ModelState.AddModelError("Documento", "El numero de docuemento no es correcto");
                valid = false;
            }

            if(profileData.Age <= 0 || profileData.Age>= 100)
            {
                ModelState.AddModelError("Edad", "La edad debe ser un valor numerico mayor a 0 y menor a 100 años");
                valid = false;
            }

            if (!valid)
            {
                return View("Nuevo",profileData);
            }

            //IF todo bien       

            _Manager.Save(profileData);

            //Retornar a la vista de listado
            return RedirectToAction("ProfileDataList");
        }

        private bool IsDniValid(string dni)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(dni))
            {
                valid = false;
                return valid;
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


        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(ProfileData profileData)
        {
            ModelState.Clear(); //Clear Model State errors 
            ProfileData model = _Manager.Get(profileData.Id);
            return View("Edit", model);
        }


        [HttpPost]
        [Route("Update")]
        public IActionResult Update(ProfileData profileData)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(profileData.UserName))
            {
                ModelState.AddModelError("NombreUsuario", "El nombre de usuario no es correcto");

            }

            if (!IsValidMail(profileData.Email))
            {
                ModelState.AddModelError("Email", "El mail ingresado no corresponde al formato de mail");
                valid = false;
            }

            if (!IsDniValid(profileData.DNI))
            {
                ModelState.AddModelError("Documento", "El numero de docuemento no es correcto");
                valid = false;
            }

            if (!valid)
                return RedirectToAction("Edit",profileData.Id);

            _Manager.Update(profileData); 
            return RedirectToAction("ProfileDataList");

        }

        [HttpGet]
        public IActionResult Deletear(int id)
        {
            _Manager.Delete(id);
            return RedirectToAction("ProfileDataList");
        }

    }
}
