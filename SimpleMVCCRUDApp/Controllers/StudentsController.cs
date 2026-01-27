using Microsoft.AspNetCore.Mvc;
using SimpleMVCCRUDApp.Data;
using System.Linq;
using SimpleMVCCRUDApp.Models;

namespace SimpleMVCCRUDApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentmvcDbContext _dbContext;
        public StudentsController(StudentmvcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var students = _dbContext.Students.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id) 
        {
            var student = _dbContext.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Update(student);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _dbContext.Students.Find(id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _dbContext.Students.Find(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
