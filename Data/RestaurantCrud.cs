using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class RestaurantCrud
    {
        RestaurantEntities db = new RestaurantEntities();

        //Restaurants

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return db.Restaurants.ToList();
        }

        public Restaurant GetRestaurant(int id)
        {
            return db.Restaurants.Find(id);
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void RemoveRestaurant(Restaurant restaurant)
        {
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }
    }
}
