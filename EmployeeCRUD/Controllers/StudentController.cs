using StudentCRUD.Data;
using StudentCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentCRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objCatlist = _context.Students;
            return View(objCatlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student stdobj)
        {
            if (ModelState.IsValid)
            {
                var cdate=DateTime.Now;
                stdobj.DateOfBirth = cdate;

                _context.Students.Add(stdobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(stdobj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var stdfromdb = _context.Students.Find(id);

            if (stdfromdb == null)
            {
                return NotFound();
            }
            return View(stdfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student stdobj)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(stdobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(stdobj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var stdfromdb = _context.Students.Find(id);
         
            if (stdfromdb == null)
            {
                return NotFound();
            }
            return View(stdfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletestd(int? id)
        {
            var deleterecord = _context.Students.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Students.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }


    }
}
