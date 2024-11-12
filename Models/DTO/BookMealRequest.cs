using BookMyMeal.Models.Domain;

namespace BookMyMeal.Models.DTO
{
    public class BookMealRequest
    {
        public string Note { get; set; }
        public double payment { get; set; }
        public Guid empId { get; set; }
        public List<MealBookingDetailRequest> MealBookingDetails { get; set; } = new List<MealBookingDetailRequest>();
    }
}
