using System.ComponentModel.DataAnnotations;

namespace BookMyMeal.Models.Domain
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public string day { get; set; }
        [Required]
        public MealType mealType { get; set; }
        [Required]
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<BookMeal> BookMeal { get; set; }

    }
}