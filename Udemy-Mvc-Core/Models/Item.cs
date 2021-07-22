
using System.ComponentModel;

namespace Udemy_Mvc_Core.Models
{
    public class Item
    {
        
        public int Id { get; set; }
        public string Borrower { get; set;  } 
        public string Lender { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set;  }

    }
}
