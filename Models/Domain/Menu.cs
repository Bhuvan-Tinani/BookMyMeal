using System.ComponentModel.DataAnnotations;

namespace BookMyMeal.Models.Domain
{
    public class Menu
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }

    }
}
