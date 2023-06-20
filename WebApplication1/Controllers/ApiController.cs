using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services.UserService;

namespace WebApplication1.Controllers
{
    public class ApiController : Controller
    {
        private readonly IUserService _userService;
        public IActionResult Index()
        {
            return View();
        }

        public ApiController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("/update")]
        public IActionResult Update(UpdateUserDTO userDTO)
        {
            try
            {
 //               Console.WriteLine(userDTO.ID);
                _userService.update(userDTO.ID, new User() { ID = userDTO.ID, UserName = userDTO.UserName, Address = userDTO.Address });
                
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        public IActionResult DeleteRecord(int id)
        {
            Console.WriteLine(id);
            _userService.delete(id);
            return Redirect("/");
        }

        [HttpPost("/Home/add")]
        public IActionResult addUser(UserAddDTO userAddDTO)
        {
            Console.WriteLine("test");
            try
            {
                if (!ModelState.IsValid)
                {
                    List<User> users = _userService.get();
                    ViewBag.Users = users.ToList();
                    return View("~/Views/CRUD/AddUser.cshtml", userAddDTO);
                }
                User user = new User() { UserName = userAddDTO.UserName, Address = userAddDTO.Address };
                

                Console.WriteLine(user.UserName);
                _userService.add(user);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }
    }
}
