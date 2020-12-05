using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }

        public IActionResult OnGet(int restaurantID)
        {
            Restaurant = restaurantData.GetRestaurantByID(restaurantID);
            if (Restaurant == null)
            {
                return RedirectToPage("/Restaurants/NotFound");
            }
            return Page();
        }
    }
}
