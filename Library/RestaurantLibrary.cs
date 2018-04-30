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

        public static void TopThreeRestaurants()
        {
            Console.WriteLine("Top Three Restaurants:");
            var topThree = crud.GetAllRestaurants().Take(3).ToList();
            foreach (var r in CollectionLib.SortDescending<Restaurant>(topThree))
            {
                PrintRestaurantShort(r);
            }
        }

        public static void PrintRestaurantsDESC()
        {
            var restaurants = crud.GetAllRestaurants();

            foreach (var r in Restaurant.SortDescending(restaurants.ToList()))
            {
                PrintRestaurantShort(r);
            }
        }

        public static void PrintRestaurantsASC()
        {
            var restaurants = crud.GetAllRestaurants();

            foreach (var r in Restaurant.SortAscending(restaurants.ToList()))
            {
                PrintRestaurantShort(r);
            }
        }

        public static void PrintRestaurant()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = int.Parse(Console.ReadLine());

            //show restaurant
            var restaurant = crud.GetRestaurant(id);
            Console.WriteLine($"{restaurant.name}, {restaurant.AvgRating()} rating, {restaurant.Reviews.Count} Reviews");
            foreach (var r in restaurant.Reviews)
            {
                Console.WriteLine($"\t{r.username} rated {r.rating}");
            }
        }

        public static void PrintRestaurantFull(Restaurant restaurant)
        {
            //show restaurant
            PrintRestaurantShort(restaurant);
            foreach (var r in restaurant.Reviews)
            {
                Console.WriteLine($"\t{r.username} rated {r.rating}");
            }
        }

        public static void PrintRestaurantShort(Restaurant restaurant)
        {
            //show restaurant
            Console.WriteLine($"{restaurant.id} - {restaurant.name}, {restaurant.AvgRating()} rating, {restaurant.Reviews.Count} Reviews");
        }

        public static void PrintRestaurants()
        {
            foreach (var r in crud.GetAllRestaurants())
            {
                Console.WriteLine($"{r.name} [{r.AvgRating()}]");
            }
        }

        public static void PrintReviews()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = int.Parse(Console.ReadLine());
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
                foreach (var restaurant in restaurants)
                {
                    PrintRestaurantShort(restaurant);
                }
            }
        }
    }

    
}
