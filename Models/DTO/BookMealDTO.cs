namespace BookMyMeal.Models.DTO
{
    public class BookMealDTO
    {
        public Guid id { get; set; }
        public DateTime bookingDate { get; set; }
        public string Note { get; set; }
        public double payment { get; set; }
        public int numberOfMeal { get; set; }
        public EmployeeDTO employee { get; set; }
        public List<MealDTO> meals { get; set; }=new List<MealDTO>();
    }
}
