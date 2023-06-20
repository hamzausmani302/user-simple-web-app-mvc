using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
           

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void delete(int ID)
        {
            User user = _dataContext.Users.Where<User>(user => user.ID == ID).FirstOrDefault();
            Console.WriteLine(user.UserName);
            if(user != null)
            {
               _dataContext.Users.Remove(user);
            }
            _dataContext.SaveChanges();

        }

        public void add(User user)
        {
            _dataContext.Users?.Add(new User() {ID=user.ID , Address = user.Address , UserName = user.UserName });
            _dataContext.SaveChanges();
            
            
        }

        public List<User> get()
        {
            
            if(_dataContext.Users == null)
            {
                return new List<User>();
            }
            List<User> users = _dataContext.Users.ToList();
            return users;

        }
        public User update(int ID, User user)
        {
            
            User _user = _dataContext.Users.Where<User>(user => user.ID == ID).FirstOrDefault();
            Console.WriteLine("t"+user.UserName);
            if (_user != null)
            {

                _user.UserName = user.UserName;
                _user.Address = user.Address;

            }
            _dataContext.SaveChanges();
            return user;
        }
    }
}
