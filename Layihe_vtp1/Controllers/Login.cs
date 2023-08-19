using Layihe_vtp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace VTP_project.Controllers
{
    public class Login : Controller
    {
        vtp2Context db = new vtp2Context();
        public IActionResult Index()
        {
            ViewBag.Users = db.Users.ToList();
            return View();
        }
        public IActionResult Index1(User u)
        {
            var users = db.Users.Join(
                db.Statuses,
                u => u.StatusId,
                s => s.Id,
                (user, status) => new
                {
                    Id=user.Id,
                    Name = user.Email,
                    Password = user.Password,
                    UserStatus = status.StatusName,
                }).SingleOrDefault(x => x.Name == u.Email && x.Password == u.Password);
            if (users != null)
            {
                if (users.UserStatus == "Admin")
                {
                    TempData["UserId"] = users.Id;
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Login");
        }
    }
}