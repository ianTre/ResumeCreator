using ResumeCreator.Models;

namespace ResumeCreator.Manager
{
    public class DatosPersonalesManager
    {
        public List<DatosPersonales> ObtenerDatosPersonales()
        {
            return ObtenerDatosBD();
        }

        private List<DatosPersonales> ObtenerDatosBD()
        {
            List<DatosPersonales> lista = new List<DatosPersonales>();

            lista.Add(new DatosPersonales() 
            {
                Id = 1,
                Documento = "38700240",
                Email = "ianntrejo96@gmail.com",
                NombreUsuario = "IanTre",
                PerfilPropio = true
            });

            DatosPersonales usuario2 = new DatosPersonales();

            usuario2.Id = 2;
            usuario2.Documento = "28500250";
            usuario2.Email = "maurokucich@gmail.com";
            usuario2.NombreUsuario = "Mauro Ku";
            usuario2.PerfilPropio = false;
            lista.Add(usuario2);

            

            return lista;
        }
    }
}
