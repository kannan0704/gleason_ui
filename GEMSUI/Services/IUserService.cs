using GEMSUI.Models;

namespace GEMSUI.Services
{
    public interface IUserService
    {
        public List<User> GetUsers(string token);
        public User GetUser(int id, string token);
        public string DeleteUser(int id, string token);
        public string SaveUser(User user, string token);
        public string Login(Login login);
    }
}
