using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurantToBeDeleted = GetRestaurantByID(restaurantId);
            db.Restaurants.Remove(restaurantToBeDeleted);
            return restaurantToBeDeleted;
        }

        public Restaurant GetRestaurantByID(int restaurantID)
        {
            var restaurant = db.Restaurants.Find(restaurantID);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return db.Restaurants.Where(x => x.Name == name || string.IsNullOrEmpty(name));
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
