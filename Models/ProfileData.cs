namespace ResumeCreator.Models
{
    public class ProfileData
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DNI { get; set; }
        public string UserAddress { get; set; }
        public bool IsMainProfile { get; set; }
        public List<ProfileData> RelatedProfiles { get; set; }

    }
}
