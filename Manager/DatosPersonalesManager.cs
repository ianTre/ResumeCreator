using ResumeCreator.Models;

namespace ResumeCreator.Manager
{
    public class DatosPersonalesManager
    {


        List<DatosPersonales> lista;

        public DatosPersonalesManager() {
            lista = new List<DatosPersonales>();
            PopularDatos();
        }
        public List<DatosPersonales> ObtenerDatosPersonales()
        {
            return ObtenerDatosBD();
        }

        internal void GuardarDatos(DatosPersonales datosPersonales)
        {
            lista.Add(datosPersonales);
        }

        private List<DatosPersonales> ObtenerDatosBD()
        {
            return lista;
        }

        private void PopularDatos()
        {
            lista.Add(new DatosPersonales()
            {
                Id = 1,
                Documento = "38700240",
                Email = "ianntrejo96@gmail.com",
                NombreUsuario = "IanTre",
                IsMainProfile = true
            });

            DatosPersonales usuario2 = new DatosPersonales();

            usuario2.Id = 2;
            usuario2.Documento = "28500250";
            usuario2.Email = "maurokucich@gmail.com";
            usuario2.NombreUsuario = "Mauro Ku";
            usuario2.IsMainProfile = false;
            lista.Add(usuario2);
        }
    }
}
