using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy_Mvc_Core.Date;
using Udemy_Mvc_Core.Models;

namespace Udemy_Mvc_Core.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly Udemy_Mvc_Core.Date.Udemytestdbcontext _db;

        public ExpenseTypeController(Udemytestdbcontext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> obj = _db.expenseTypes;
            return View(obj);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }
        [HttpGet]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.expenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ExpenseType obj)
        {

            if (ModelState.IsValid)
            {
                _db.expenseTypes.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("index");
            }
            return View(obj);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.expenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.expenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.expenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.expenseTypes.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("index");
            }
            return View(obj);


        }
    }
}
