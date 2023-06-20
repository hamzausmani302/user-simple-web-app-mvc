using WebApplication1.Models;

namespace WebApplication1.Services.UserService
{
    public interface IUserService
    {
        public List<User> get();
        public void add(User user);

        public void delete(int ID);

        public User update(int ID, User user);

    }
}
