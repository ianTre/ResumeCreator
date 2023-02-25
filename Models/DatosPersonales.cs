namespace ResumeCreator.Models
{
    public class DatosPersonales
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public bool PerfilPropio { get; set; }
    }
}
