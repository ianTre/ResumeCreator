using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ResumeCreator.Models;
using ResumeCreator.Repositories;
using System.Drawing.Text;

namespace ResumeCreator.Manager
{
    public class AccountManager : IAccountManager
    {
        private UserRepository _UserRepository;
        private ProfileDataRepository _ProfileDataRepository;
        public AccountManager()
        {
            _UserRepository = new UserRepository();
            _ProfileDataRepository = new ProfileDataRepository();
        }
        public void Add(User user)

        {
            ProfileData profile = new ProfileData();
            int Iduser = _UserRepository.Save(user);

            profile.UserId = Iduser;
            profile.UserName = user.UserName;
            profile.Email = user.Email;
            profile.UserAddress = user.UserAddress;
            profile.Age = user.Age;
            profile.DNI = user.DNI;
            profile.IsMainProfile = true;

            _ProfileDataRepository.Save(profile);
            
        
        }
    }
}
