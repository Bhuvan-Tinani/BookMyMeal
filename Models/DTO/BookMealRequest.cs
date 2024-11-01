using BookMyMeal.Models.Domain;

namespace BookMyMeal.Models.DTO
{
    public class BookMealRequest
    {
        public string Note { get; set; }
        public double payment { get; set; }
        public int numberOfMeal { get; set; }
        public Guid empId { get; set; }
        public int[] mealIds { get; set; }
    }
}
