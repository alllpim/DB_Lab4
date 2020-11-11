using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenMVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KindergartenMVCWebApp.Controllers
{
    public class StaffController : Controller
    {
        private kindergartenContext db;

        public StaffController(kindergartenContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult Staff()
        {
            var staff = db.Staff.Include(d => d.Position).Take(20).ToList();
            return View(staff);
        }

    }
}
