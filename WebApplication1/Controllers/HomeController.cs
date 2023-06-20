using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services.UserService;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger , IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<User> users = _userService.get();
            ViewBag.Users = users.ToList();
            return View();
        }
       
        public IActionResult UpdateRecord(string userObjectString)
        {
            try
            {
                User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(userObjectString);
                ViewBag.User = user;
                //_userService.update(user.ID, user);
                return View("~/Views/CRUD/UpdateUserPage.cshtml");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/addUser")]
        public IActionResult addUserPage()
        {
            
            List<User> users = _userService.get();
            ViewBag.Users = users.ToList();
            
            return View("~/Views/CRUD/AddUser.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}