namespace BookMyMeal.Models.DTO
{
    public class MealBookingDetailRequest
    {
        public int MealId { get; set; }
        public int NumberOfMeal { get; set; }
        public DateTime Date { get; set; }
    }
}
