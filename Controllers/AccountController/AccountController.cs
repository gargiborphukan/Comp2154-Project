using Comp2154_System_Development_Project.Data;
using Comp2154_System_Development_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Comp2154_System_Development_Project.Controllers

{    //2ND PART
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)

        {
            _context = context;
        }

        //-----------Register------------>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //Check if email already exists
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email Already Exists");
                return View(model);
            }

            //create new User
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["message"] = "Registration Successful";
            return RedirectToAction("Login");
        }

        //----------------Login----------->
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Find User with matching email and password
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("Email", "Invalid email or password");
                return View(model);
            }

            //store user id in session
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index", "Home");
        }

        //------------Logout------------>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");

        }

        //-----------Profile(GET)---------->
        [HttpGet]
        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return RedirectToAction("Login");

            var model = new ProfileViewModel
            {
                FullName = user.FullName,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber,
            };

            return View(model);
        }

        //------------Profile(POST)---------->
        [HttpPost]
        public IActionResult Profile(ProfileViewModel model)

        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return RedirectToAction("Login");

            if (!ModelState.IsValid)
                return View(model);

            //Update userinfro
            user.FullName = model.FullName;
            user.Birthday = model.Birthday;
            user.PhoneNumber = model.PhoneNumber;


            _context.SaveChanges();

            TempData["Success"] = "Profile updated successfully";
            return RedirectToAction("Profile");
        }
    }

}