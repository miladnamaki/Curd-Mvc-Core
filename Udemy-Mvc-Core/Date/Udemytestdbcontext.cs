using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy_Mvc_Core.Models;

namespace Udemy_Mvc_Core.Date
{
    public class Udemytestdbcontext : DbContext
    {
        public Udemytestdbcontext(DbContextOptions<Udemytestdbcontext> option) : base(option)
        {

        }
        public DbSet<Item> items { get; set; }
        public DbSet<Expense> expenses { get; set; }
        public DbSet<ExpenseType> expenseTypes { get; set; }
     
    }
}
