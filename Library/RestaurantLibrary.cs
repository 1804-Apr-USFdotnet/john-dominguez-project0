using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Library;

namespace library
{
    public class RestaurantLibrary
    {
        private static RestaurantCrud crud = new RestaurantCrud();

        public static string RestaurantToString(List<Restaurant> restaurants)
        {
            string s = $"{string.Join("\n", restaurants)}";

            return s;
        }

        public static List<Restaurant> TopThreeRestaurants(List<Restaurant> restaurants)
        {
           return Restaurant.SortDescending(restaurants).Take(3).ToList();
        }

        public static Restaurant LowestRatedRestaurant(List<Restaurant> restaurants)
        {
            return Restaurant.SortAscending(restaurants).Take(1).ToList()[0];
        }


        //Print Methods

        public void PrintRestaurant(Restaurant restaurant)
        {
            Console.WriteLine(restaurant.ToString());
        }
        
        public static void PrintTopThreeRestaurants()
        {
            Console.WriteLine("Top Three Restaurants:");
            var topThree = TopThreeRestaurants(crud.GetAllRestaurants().ToList());
            Console.WriteLine(RestaurantToString(topThree));
        }

        public static void PrintRestaurantsDesc()
        {
            var restaurants = crud.GetAllRestaurants();

            Console.WriteLine(RestaurantToString(Restaurant.SortDescending(restaurants.ToList())));
        }

        public static void PrintRestaurantsAsc()
        {
            var restaurants = crud.GetAllRestaurants();
            Console.WriteLine(RestaurantToString(Restaurant.SortAscending(restaurants.ToList())));
        }

        public static void PrintRestaurant()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            //show restaurant
            var restaurant = crud.GetRestaurant(id);
            Console.WriteLine($"{restaurant.name}, {restaurant.AvgRating()} rating, {restaurant.Reviews.Count} Reviews");
            foreach (var r in restaurant.Reviews)
            {
                Console.WriteLine($"\t{r.username} rated {r.rating}");
            }
        }

        public static void PrintReviews()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = Int32.Parse(Console.ReadLine());
            Restaurant restaurant = crud.GetRestaurant(id);

            foreach (var review in restaurant.Reviews)
            {
                Console.WriteLine($"{review.id} - rated {review.rating}, {review.body} by {review.username}");
            }
        }

        public static void SearchRestaurant()
        {
            Console.Write("Enter search term: ");
            string input = Console.ReadLine();
            var restaurants = Restaurant.SearchRestaurants(crud.GetAllRestaurants().ToList(), input);
            if (restaurants.Count == 0)
            {
                Console.WriteLine("No Matches Found!");
            }
            else
            {
                Console.WriteLine($"Found {restaurants.Count} Matches:");
                Console.WriteLine(RestaurantToString(restaurants));
            }
        }

        public static void SerializeDB()
        {
            Serializer.Serialize(crud.GetAllRestaurants(), "database.json");
            Console.WriteLine($"Serialization completed! Saved to database.json");
        }

        public static void DeserializeJSON()
        {
            List<Restaurant> restaurants = Library.Serializer.DeserializeRestaurantJSON();
        }
    }
}
