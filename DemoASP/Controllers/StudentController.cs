using DemoASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoASP.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student Student1 = new Student();
            Student1.Id = 1;
            Student1.Name = "Weerapon";
            Student1.Score = 100;

            var Student2 = new Student();
            Student2.Id = 2;
            Student2.Name = "SomChai";
            Student2.Score = 50;

            Student Student3 = new Student();
            Student3.Id = 3;
            Student3.Name = "SomMai";
            Student3.Score = 42;

            List<Student> allStudents =  new List<Student>();
            allStudents.Add(Student1);
            allStudents.Add(Student2);
            allStudents.Add(Student3);

            return View(allStudents);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
