using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
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
