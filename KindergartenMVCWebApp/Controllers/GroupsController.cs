using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenMVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenMVCWebApp.Controllers
{
    public class GroupsController : Controller
    {
        private kindergartenContext db;

        public GroupsController(kindergartenContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult Groups()
        {
            return View(db.Groups.Take(20).ToList());
        }
    }
}
