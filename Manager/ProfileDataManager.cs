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
        public List<ProfileData> GetAllProfileData()
        {
            return _repository.GetAll();
        }

        public void Save(ProfileData model)
        {
            _repository.Save(model);
        }

        public ProfileData Get(int userId)
        {
            return _repository.Get(userId);
        }

        internal void Update(ProfileData profileData)
        {
            _repository.Update(profileData);
            return;
        }

        internal void Delete(int id)
        {
            _repository.Delete(id);
            return;
        }
    }
}
