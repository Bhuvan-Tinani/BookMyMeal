using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyMeal.Models.Domain
{
    public class MealType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string type { get; set; }
        public virtual ICollection<Meal> Meal { get; set; }
    }
}


