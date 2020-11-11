using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenMVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenMVCWebApp.Controllers
{
    public class GroupTypesController : Controller
    {
        private kindergartenContext db;

        public GroupTypesController(kindergartenContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult GroupTypes()
        {
            return View(db.GroupTypes.Take(20).ToList());
        }
    }
}
