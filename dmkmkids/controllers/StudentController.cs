using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dmkmkids.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Models.DmKmDatabaseContext context = new Models.DmKmDatabaseContext();

            var StudentList = context.Student.ToList();

            return View(StudentList);
        }

        [HttpGet]
        public IActionResult StudentDetail(int id)
        {
            Models.DmKmDatabaseContext context = new Models.DmKmDatabaseContext();
            var entity = context.Student.FirstOrDefault(m => m.Id == id);

            return View(entity);
        }

        [HttpPost]
        public IActionResult StudentDetail(Models.Student entity)
        {
            Models.DmKmDatabaseContext context = new Models.DmKmDatabaseContext();
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return View(entity);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Models.Student studentEntity)
        {
            Models.DmKmDatabaseContext context = new Models.DmKmDatabaseContext();
            context.Student.Add(studentEntity);
            context.SaveChanges();

            return Redirect($"./StudentDetail/{studentEntity.Id}");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Models.DmKmDatabaseContext context = new Models.DmKmDatabaseContext();
            var entity = context.Student.FirstOrDefault(m => m.Id == id);
            context.Student.Remove(entity);
            context.SaveChanges();

            return Redirect("/");
        }
    }
}
