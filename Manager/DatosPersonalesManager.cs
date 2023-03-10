using ResumeCreator.Models;

namespace ResumeCreator.Manager
{
    public class ProfileDataManager
    {


        List<ProfileData> lista;

        public ProfileDataManager() {
            lista = new List<ProfileData>();
            PopularDatos();
        }
        public List<ProfileData> GetProfileData()
        {
            return ObtenerDatosBD();
        }

        internal void GuardarDatos(ProfileData datosPersonales)
        {
            lista.Add(datosPersonales);
        }

        private List<ProfileData> ObtenerDatosBD()
        {
            return lista;
        }

        private void PopularDatos()
        {
            lista.Add(new ProfileData()
            {
                Id = 1,
                DNI = "38700240",
                Email = "ianntrejo96@gmail.com",
                UserName = "IanTre",
                IsMainProfile = true
            });

            ProfileData usuario2 = new ProfileData();

            usuario2.Id = 2;
            usuario2.DNI = "28500250";
            usuario2.Email = "maurokucich@gmail.com";
            usuario2.UserName = "Mauro Ku";
            usuario2.IsMainProfile = false;
            lista.Add(usuario2);
        }
    }
}
