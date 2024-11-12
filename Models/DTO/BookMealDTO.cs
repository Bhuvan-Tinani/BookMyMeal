namespace BookMyMeal.Models.DTO
{
    public class BookMealDTO
    {
        public Guid id { get; set; }
        public DateTime bookingDate { get; set; }
        public string Note { get; set; }
        public double payment { get; set; }
        public string Status { get; set; }
        public EmployeeDTO employee { get; set; }
        public List<BookedMealDetailsDTO> BookedMealDetails { get; set; } = new List<BookedMealDetailsDTO>();
    }
}
