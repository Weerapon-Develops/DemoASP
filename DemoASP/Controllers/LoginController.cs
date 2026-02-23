using DemoASP.Data;
using DemoASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoASP.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly PasswordHasher<User> _passwordHasher;

        public LoginController(ApplicationDBContext db)
        {
            _db = db;
            _passwordHasher = new PasswordHasher<User>();
        }

        public IActionResult Index()
        {
            return View();
        }

        // สมัครสมาชิก (GET)
        public IActionResult Register()
        {
            return View();
        }

        // สมัครสมาชิก (POST)
        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            var user = new User
            {
                Username = username
            };

            // 🔐 Hash Password ก่อนบันทึก
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            _db.Users.Add(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                // 🔐 ตรวจสอบรหัสผ่านแบบ Hash
                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

                if (result == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    return RedirectToAction("Index", "Student");
                }
            }

            ViewBag.Error = "Username หรือ Password ไม่ถูกต้อง";
            return View();
        }

        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // ถ้าใช้ Session
            return RedirectToAction("Index", "Login");
        }
    }

}