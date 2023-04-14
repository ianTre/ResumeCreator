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
        public int Age { get; set; }
        public int DependentId { get; set; }  // TODO : add reference to the user logged when the login controller is already developed. 
        public List<ProfileData> RelatedProfiles { get; set; }

    }
}
