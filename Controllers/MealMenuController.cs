using BookMyMeal.Models.Domain;
using BookMyMeal.Models.DTO;
using BookMyMeal.Respositaries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealMenuController : ControllerBase
    {
        private readonly IMealMenuRepo mealMenuRepo;

        public MealMenuController(IMealMenuRepo mealMenuRepo)
        {
            this.mealMenuRepo = mealMenuRepo;
        }

        [HttpPost]
        [Route("Menu")]
        public async Task<IActionResult> createMenu([FromBody]MenuRequestDTO request)
        {
            var listMenus = new List<Menu>();
            foreach(var menu in request.Menus)
            {
                var MENU=new Menu();
                MENU.name = menu;
                listMenus.Add(MENU);
            }
            listMenus=await mealMenuRepo.createAsyncMenus(listMenus);
            var response = new List<MenuDTO>();
            foreach(var menu in listMenus)
            {
                var menuDto = new MenuDTO()
                {
                    id = menu.id,
                    name = menu.name,
                };
                response.Add(menuDto);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Meal")]
        public async Task<IActionResult> createMeal([FromBody]CreateMealRequestDTO request)
        {
            var mealType=await mealMenuRepo.GetMealType(request.mealTypeId);
            var meal = new Meal()
            {
                name = request.name,
                description = request.description,
                price = request.price,
                day = request.day,
                mealType = mealType,
                Menus = new List<Menu>(),
            };
            foreach(var menuId in request.menuId)
            {
                var existingMenu=await mealMenuRepo.getMenu(menuId);
                if(existingMenu is not null)
                {
                    meal.Menus.Add(existingMenu);
                }
            }
            meal = await mealMenuRepo.createMealAsync(meal);
            var response = new MealDTO()
            {
                Id = meal.Id,
                name = meal.name,
                description = meal.description,
                price = meal.price,
                day = meal.day,
                mealType = new MealTypeDTO()
                {
                    id = meal.mealType.id,
                    type = meal.mealType.type
                },
                Menus = meal.Menus.Select(menu => new MenuDTO()
                {
                    id = menu.id,
                    name = menu.name
                }).ToList()
            };
            return Ok(response);
        }

        [HttpGet]
        [Route("Menu")]
        public async Task<IActionResult> getAllMenu()
        {
            var menus=await mealMenuRepo.getAllMenuAsync();
            var response=new List<MenuDTO>();
            foreach(var menu in menus)
            {
                var existingMenu = new MenuDTO()
                {
                    id = menu.id,
                    name = menu.name,
                };
                response.Add(existingMenu);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Meal")]
        public async Task<IActionResult> getAllMeal()
        {
            var meals=await mealMenuRepo.getAllMealAsync();
            var response=new List<MealDTO>();
            foreach (var meal in meals)
            {
                var existingMeal = new MealDTO()
                {
                    Id = meal.Id,
                    name = meal.name,
                    description = meal.description,
                    day = meal.day,
                    price = meal.price,
                    mealType = new MealTypeDTO()
                    {
                        id = meal.mealType.id,
                        type = meal.mealType.type,
                    },
                    Menus = meal.Menus.Select(menu => new MenuDTO()
                    {
                        id = menu.id,
                        name = menu.name
                    }).ToList()
                };
                response.Add(existingMeal);
            }
            return Ok(response);
        }
    }
}
