using TourMe.Data.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public User GetUserByName(string UserName)
        {
            User User = this.DbContext.Users.Where(p => p.Username == UserName).FirstOrDefault();
            return User;
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        User GetUserByName(string UserName);
    }
}
