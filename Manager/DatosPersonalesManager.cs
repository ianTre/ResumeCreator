using ResumeCreator.Models;
using ResumeCreator.Repositories;

namespace ResumeCreator.Manager
{
    public class ProfileDataManager
    {

        private ProfileDataRepository _repository;
        

        public ProfileDataManager() {
            _repository = new ProfileDataRepository();
        }
        public List<ProfileData> GetProfileData()
        {
            return _repository.GetAll();
        }

        public void Save(ProfileData model)
        {
            _repository.Save(model);
        }
        
    }
}
