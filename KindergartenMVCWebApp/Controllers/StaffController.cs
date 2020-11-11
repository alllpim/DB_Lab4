using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenMVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

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
            return View(db.Staff.Take(20).ToList());
        }

    }
}
