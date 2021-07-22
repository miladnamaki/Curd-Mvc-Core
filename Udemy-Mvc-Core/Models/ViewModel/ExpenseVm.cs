using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy_Mvc_Core.Models.ViewModel
{
    public class ExpenseVm
    {
        public Expense Expenses { get; set; }
        public IEnumerable<SelectListItem> TypeDrowDown { get; set; }
    }
}
