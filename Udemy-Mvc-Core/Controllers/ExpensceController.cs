using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy_Mvc_Core.Date;
using Udemy_Mvc_Core.Models;
using Udemy_Mvc_Core.Models.ViewModel;

namespace Udemy_Mvc_Core.Controllers
{
    public class ExpensceController : Controller
    {
        private readonly Udemy_Mvc_Core.Date.Udemytestdbcontext _db;

        public ExpensceController(Udemytestdbcontext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //IEnumerable<Expense> objList = _db.expenses;

            //foreach (var obj in objList)
            //{
            //    obj.ExpenseType = _db.expenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            //}
            var query = _db.expenses.Where(x => x.ExpenseTypeId == x.ExpenseType.Id).Select(n => new ExpanseSerchVm
            {
                id=n.Id,
              Amount=n.Amount,
              ExpenseName=n.ExpenseName,
              ExpenseTypeName= n.ExpenseType.Name,

            }).ToList();


            return View(query);

        }
        [HttpGet]
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.expenseTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});
            //ViewBag.TypeDropDown = TypeDropDown;
            ExpenseVm expense = new ExpenseVm()
            {
                Expenses = new Expense(),
                TypeDrowDown = _db.expenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(expense);

        }
        [HttpGet]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(Expense obj)
        {

            if (ModelState.IsValid)
            {
                _db.expenses.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("index");
            }
            return View(obj);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null|| id==0)
            {
                return NotFound();
            }

            var obj = _db.expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id )
        {
            var obj = _db.expenses.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            _db.expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
             


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVm obj )
        {
            if (ModelState.IsValid)
            {
                _db.expenses.Add(obj.Expenses);
                _db.SaveChanges();

                return RedirectToAction("index");
            }
            return View(obj);


        }
    }
}
