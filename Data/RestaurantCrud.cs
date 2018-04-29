using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class RestaurantCrud
    {
        RestaurantEntities db = new RestaurantEntities();

        public IEnumerable<Restaurant> ShowAllRestaurants()
        {
            return db.Restaurants.ToList();
        }
    }
}
