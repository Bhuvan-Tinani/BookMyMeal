namespace BookMyMeal.Models.DTO
{
    public class MealDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string day { get; set; }
        public MealTypeDTO mealType { get; set; }
        public List<MenuDTO> Menus { get; set; }=new List<MenuDTO>();
    }
}
