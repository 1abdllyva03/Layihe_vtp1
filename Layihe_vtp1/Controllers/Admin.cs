
using Layihe_vtp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VTP_project.Controllers
{
    public class Admin : Controller
    {
        vtp2Context db = new vtp2Context();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Members()
        {
            ViewBag.User = db.Users.ToList();
            ViewBag.Gender=db.Genders.ToList();
            ViewBag.Department = db.Departments.ToList();
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult AddPerson(User u)
        {


            //User p = new User();
            //p.FirstName = FirstName;
            //p.LastName = LastName;
            //p.Email = Email;
            //p.University = University;
            //p.DepId = DepId;
            //db.Users.Add(p);
            //db.SaveChanges();
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Members");

        }

        public IActionResult UserDelete(int id)
        {
            User b = db.Users.Find(id);
            db.Users.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Members");
        }

        public IActionResult UpdateUser(int id, User b)
        {
            User bb = db.Users.Find(id);
            bb.FirstName = b.FirstName;
            bb.LastName = b.LastName;
            bb.University = b.University;
            bb.Email = b.Email;
            bb.Age = b.Age;
            db.SaveChanges();
            return RedirectToAction("Members");
        }
        public IActionResult Departments()
        {
            
            ViewBag.Department = db.Departments.ToList();
            ViewBag.User = db.Users.Join(
               db.Departments,
               u => u.DepId,
               d => d.Id,
               (user, department) => new
               {
                   email = user.Email,
                   firstname = user.FirstName,
                   lastname = user.LastName,
                   university = user.University,
                   Age=user.Age,
                   depname = department.DepName,
               }).ToList();

            return View();
        }
        public ActionResult DepUsers(int departmentId)
        {
            ViewBag.User = db.Users.ToList();
            ViewBag.UserCount = db.Users.Count();
            ViewBag.Department = db.Departments.ToList();
            TempData["DepId"] = departmentId;
            ViewBag.UserId = departmentId;

            return View();
        }

        public async Task<IActionResult> Index1()
        {
            var statuses = db.Statuses.Include(s => s.Users).ToList();

            return RedirectToAction("Index");
        }

        public ActionResult User()
        {
            int userId = 0;
            if (TempData.ContainsKey("UserId") && TempData["UserId"] != null)
            {
                userId = (int)TempData["UserId"];
            }

            ViewBag.UserId = userId;
            ViewBag.User=db.Users.ToList();
            return View();
        }
        public ActionResult AddEvents(Event e)
        {
            
            db.SaveChanges();
            return RedirectToAction("Events");
        }

    }
}
