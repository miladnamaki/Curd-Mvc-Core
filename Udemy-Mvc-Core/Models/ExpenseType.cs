using System.ComponentModel.DataAnnotations;

namespace Udemy_Mvc_Core.Models
{
    public class ExpenseType
    {
        [key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
