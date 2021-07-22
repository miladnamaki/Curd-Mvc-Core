using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy_Mvc_Core.Date;
using Udemy_Mvc_Core.Models;

namespace Udemy_Mvc_Core.Controllers
{
    public class ItemController : Controller
    {
        private readonly Udemy_Mvc_Core.Date.Udemytestdbcontext _db;

        public ItemController(Udemytestdbcontext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objlst = _db.items;

            return View(objlst);

        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
             _db.items.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
