namespace BookMyMeal.Models.Domain
{
    public class BookMeal
    {
        public Guid id { get; set; }
        public DateTime bookingDate{ get; set; }
        public string Note{ get; set; }
        public double payment { get; set; }
        public string Status { get; set; }
        public Employee employee { get; set; }
        public virtual ICollection<BookedMealDetails> BookedMealDetails { get; set; }

    }
}
