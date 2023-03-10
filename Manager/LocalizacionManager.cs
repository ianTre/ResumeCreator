using ResumeCreator.Models;

namespace ResumeCreator.Manager
{
    /// <summary>
    /// Obtiene los datos de la BASE De DATOS para Localizaciones ( PAIS y PROVINCIA) 
    /// </summary>
    public class LocationManager
    {
        public List<Country> GetLocationList()
        {
            List<Country> paises = ObtenerPaises();
            foreach (var pais in paises)
            {
                ObtenerProvinciasPorPais(pais);
            }
            return paises;
        }

        private void ObtenerProvinciasPorPais(Country pais)
        {
            if ( pais.Id == 1 )
            {
                pais.provincias.Add(new Provincia() { Id = 1, Nombre = "Buenos Aires" });
                pais.provincias.Add(new Provincia() { Id = 2, Nombre = "Santa Fe" });
                pais.provincias.Add(new Provincia() { Id = 3, Nombre = "Cordoba" });
            }
            if (pais.Id == 2)
            {
                pais.provincias.Add(new Provincia() { Id = 4, Nombre = "Rio De Janiero" });
                pais.provincias.Add(new Provincia() { Id = 5, Nombre = "Fortaleza" });
                pais.provincias.Add(new Provincia() { Id = 6, Nombre = "San Pablo" });
            }
            if (pais.Id == 3)
            {
                pais.provincias.Add(new Provincia() { Id = 7, Nombre = "Concordia" });
                pais.provincias.Add(new Provincia() { Id = 8, Nombre = "Montevideo" });
                pais.provincias.Add(new Provincia() { Id = 9, Nombre = "Colonia" });
            }
        }

        private List<Country> ObtenerPaises()
        {
            List<Country> listaPaises = new List<Country>();
            listaPaises.Add(new Country() { Id = 1 , Nombre = "Argentina"});
            listaPaises.Add(new Country() { Id = 2, Nombre = "Brasil" });
            listaPaises.Add(new Country() { Id = 3, Nombre = "Uruguay" });
            listaPaises.Add(new Country() { Id = 4, Nombre = "Paraguay" });
            return  listaPaises.OrderBy(x => x.Nombre).ToList();
        }
    }
}
