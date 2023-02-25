namespace ResumeCreator.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Provincia> provincias { get; set; }

        public Pais()
        {
            this.provincias = new List<Provincia>();
            this.Nombre = string.Empty;
        }
    }
}
