using BookMyMeal.Models.Domain;

namespace BookMyMeal.Models.DTO
{
    public class BookedMealDetailsDTO
    {
        public Guid Id { get; set; }
        public BookMeal BookMeal { get; set; }
        public MealDTO Meal { get; set; }
        public int NumberOfMeal { get; set; }
        public DateTime Date { get; set; }
    }
}
