namespace BookMyMeal.Models.DTO
{
    public class UpdateMealRequestDTO
    {
        public string name { get; set; }

        public string description { get; set; }
        public double price { get; set; }
        public string day { get; set; }
        public int mealTypeId { get; set; }
        public int[] menuId { get; set; }
    }
}
