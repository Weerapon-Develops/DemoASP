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
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index", "Login");
            }
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

        public IActionResult Edit(int? Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }
           var obj = _dbContext.Students.Find(Id);
            if (obj != null)
            {
                return View(obj);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Update(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _dbContext.Students.Find(Id);
            if (obj != null)
            {
                _dbContext.Students.Remove(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

    
    }
}
