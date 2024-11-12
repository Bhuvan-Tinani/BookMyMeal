namespace BookMyMeal.Models.Domain
{
    public class BookedMealDetails
    {
        public Guid Id{ get; set; }
        public BookMeal BookMeal { get; set; }
        public Meal Meal { get; set; }
        public int NumberOfMeal {  get; set; }
        public DateTime Date { get; set; }

    }
}
