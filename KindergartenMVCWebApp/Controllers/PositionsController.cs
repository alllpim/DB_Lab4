using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenMVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenMVCWebApp.Controllers
{
    public class PositionsController : Controller
    {
        private kindergartenContext db;

        public PositionsController(kindergartenContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult Positions()
        {
            return View(db.Positions.Take(20).ToList());
        }
    }
}
