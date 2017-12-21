using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Data.Repositories;
using TourMe.Model.Model;

namespace TourMe.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(string name = null);
        User GetUser(int id);
        User GetUser(string name);
        void CreateUser(User User);
        void EditUser(User User);
        void RemoveUser(int id);
        void SaveUser();
        void UnRemoveUser(int id);
        void ChangeUserRole(int userId, int role);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository UserRepository, IUnitOfWork unitOfWork)
        {
            this.UserRepository = UserRepository;
            this.unitOfWork = unitOfWork;
        }

        public void ChangeUserRole(int userId, int role)
        {
            User user = UserRepository.GetById(userId);
            if(user != null)
            {
                user.Role = role;
            }
            SaveUser();
        }

        public void CreateUser(User User)
        {
            User u = UserRepository.GetUserByName(User.Username);
            if (u == null)
            {
                UserRepository.Add(User);
                SaveUser();
            }
        }

        public void EditUser(User User)
        {
            User USER = UserRepository.GetById(User.Id);
            if(USER != null)
            {
                USER.Password = User.Password;
                USER.Role = User.Role;
                USER.isEnable = User.isEnable;
                USER.ImageId = User.ImageId;
            }
        }

        public User GetUser(int id)
        {
            User user = UserRepository.GetById(id);
            return user;
        }

        public User GetUser(string name)
        {
            User user = UserRepository.GetUserByName(name);
            return user;
        }

        public IEnumerable<User> GetUsers(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return UserRepository.GetAll();
            else
                return UserRepository.GetAll().Where(c => c.Username.Equals(name));
        }

        public void RemoveUser(int id)
        {
            User user = UserRepository.GetById(id);
            if(user != null)
            {
                user.isEnable = false;
            }
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        public void UnRemoveUser(int id)
        {
            User user = UserRepository.GetById(id);
            if (user != null)
            {
                user.isEnable = true;
            }
        }
    }
}
