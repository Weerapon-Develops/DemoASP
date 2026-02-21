using DemoASP.Data;
using DemoASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoASP.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDBContext _dbContext;

        public EmployeeController(ApplicationDBContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> allEmployee = _dbContext.Employees;
            return View(allEmployee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _dbContext.Employees.Find(Id);
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Update(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //public IActionResult Delete(int? Id)
        //{
        //    if (Id == null || Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _dbContext.Employees.Find(Id);
        //    if (obj != null)
        //    {
        //        _dbContext.Employees.Remove(obj);
        //        _dbContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var obj = _dbContext.Employees.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(obj);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public JsonResult GetEmployeeById(int id)
        {
            var emp = _dbContext.Employees.Find(id);
            return Json(emp);

        }
    }
}
