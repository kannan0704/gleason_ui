using GEMSUI.Models;
using GEMSUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GEMSUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserService service)
        {
            _service = service;
            _logger = logger;
        }
        [Route("Home/Login")]
        [HttpPost]
        public IActionResult Login([FromForm] Login login)
        {
            var token = _service.Login(login);
            HttpContext.Session.SetString("UserToken", token);
            if (token == null || token == "")
            {
                TempData["Error"] = "Invalid Credentials";
                return View("Index");
            }
            else
            {
                return Redirect("Dashboard");
            }
        }
        [Route("Home")]
        [Route("")]

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/CreateUser")]

        public IActionResult CreateUser()
        {
            var user = new User();
            return View("SaveUser", user);
        }
        [Route("Home/EditUser/{id}")]

        public IActionResult EditUser(int id)
        {
            var token = HttpContext.Session.GetString("UserToken").ToString();
            var user = _service.GetUser(id, token);
            if (user != null)
            {
                return View("SaveUser", user);
            }
            return NotFound();
        }
        [Route("Home/SaveUser")]

        public IActionResult SaveUser([FromForm] User user)
        {
            user.Roles = Request.Form["Roles"];
            var token = HttpContext.Session.GetString("UserToken").ToString();
            var response = _service.SaveUser(user, token);
            return Redirect("Users");
        }

        [Route("Home/DeleteUser/{id}")]

        public IActionResult DeleteUser(int id)
        {
            var token = HttpContext.Session.GetString("UserToken").ToString();
            var response = _service.DeleteUser(id, token);
            TempData["Message"] = response;
            return RedirectToAction("Users");
        }
        [Route("Home/Dashboard")]
        public IActionResult Dashboard()
        {
            var token = HttpContext.Session.GetString("UserToken").ToString();
            var users = _service.GetUsers(token);
            ViewBag.Users = users.Count;
            return View();
        }
        [Route("Home/Users")]
        public IActionResult Users()
        {
            var token = HttpContext.Session.GetString("UserToken").ToString();
            var users = _service.GetUsers(token);
            return View(users);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}