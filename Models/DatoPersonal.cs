namespace ResumeCreator.Models
{
    public class DatoPersonal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido{ get; set; }
        public int Edad { get; set; }
        public Pais pais { get; set; }
        public Provincia provincia { get; set; }
    }
}
