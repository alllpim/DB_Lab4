using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenMVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var groups = db.Groups.Include(x => x.Staff).Include(x => x.Type).Take(20).ToList();
            return View(groups);
        }
    }
}
