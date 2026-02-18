using DemoASP.Data;
using DemoASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoASP.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public StudentController(ApplicationDBContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
           IEnumerable <Student> allStudents = _dbContext.Students;


            return View(allStudents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
