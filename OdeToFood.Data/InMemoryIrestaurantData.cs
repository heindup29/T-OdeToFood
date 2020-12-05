using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryIrestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryIrestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Hein's Pizza", Location = "Doornpoort", Cuisine = CuisineType.Italian },
                new Restaurant{ Id = 2, Name = "Carma's Tacos", Location = "Centurion", Cuisine = CuisineType.Mexican },
                new Restaurant{ Id = 3 , Name = "FongLong", Location = "Roodepoort", Cuisine = CuisineType.Chinese},
            };

        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return restaurants.OrderBy(x => x.Name);
            }
            return restaurants.Where(x => x.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase)).OrderBy(x => x.Name);
        }
        public Restaurant GetRestaurantByID(int restaurantID)
        {
            return restaurants.SingleOrDefault(x => x.Id == restaurantID);
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            var restaurant = newRestaurant;
            restaurant.Id = restaurants.Count + 1;
            restaurants.Add(restaurant);
            return restaurant;
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurantToBeDeleted = restaurants.FirstOrDefault(x => x.Id == restaurantId);
            if (restaurantToBeDeleted != null)
            {
                restaurants.Remove(restaurantToBeDeleted);
            }
            return restaurantToBeDeleted;
        }
    }
}
