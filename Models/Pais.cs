namespace ResumeCreator.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Provincia> provincias { get; set; }

        public Country()
        {
            this.provincias = new List<Provincia>();
            this.Nombre = string.Empty;
        }
    }
}
