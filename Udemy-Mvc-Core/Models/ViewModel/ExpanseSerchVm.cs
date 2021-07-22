using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy_Mvc_Core.Models.ViewModel
{
    public class ExpanseSerchVm
    {
        public int id { get; set;  }
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        public string ExpenseTypeName { get; set; }
    }
}
