using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using Data;
using Library;

namespace RestaurantApp
{
    public class RestaurantApp
    {
        private RestaurantCrud crud;
        private bool _isRunning;

        public RestaurantApp()
        {
            crud = new RestaurantCrud();
            _isRunning = true;
        }

        private void TopThreeRestaurants()
        {
            Console.WriteLine("Top Three Restaurants:");
            var topThree = crud.GetAllRestaurants().Take(3).ToList();
            foreach (var r in CollectionLib.SortDescending<Restaurant>(topThree))
            {
                PrintRestaurantShort(r);
            }
        }

        private void PrintRestaurantsDESC()
        {
            var restaurants = crud.GetAllRestaurants();
           
            foreach (var r in Restaurant.SortDescending(restaurants.ToList()))
            {
                PrintRestaurantShort(r);
            }
        }

        private void PrintRestaurantsASC()
        {
            var restaurants = crud.GetAllRestaurants();

            foreach (var r in Restaurant.SortAscending(restaurants.ToList()))
            {
                PrintRestaurantShort(r);
            }
        }

        private void PrintRestaurant()
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

        private void PrintRestaurantFull(Restaurant restaurant)
        {
            //show restaurant
            PrintRestaurantShort(restaurant);
            foreach (var r in restaurant.Reviews)
            {
                Console.WriteLine($"\t{r.username} rated {r.rating}");
            }
        }

        private void PrintRestaurantShort(Restaurant restaurant)
        {
            //show restaurant
            Console.WriteLine($"{restaurant.id} - {restaurant.name}, {restaurant.AvgRating()} rating, {restaurant.Reviews.Count} Reviews");    
        }

        private void PrintRestaurants()
        {
            foreach (var r in crud.GetAllRestaurants())
            {
                Console.WriteLine($"{r.name} [{r.AvgRating()}]");
            }
        }

        private void PrintReviews()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = int.Parse(Console.ReadLine());
            Restaurant restaurant = crud.GetRestaurant(id);

            foreach (var review in restaurant.Reviews)
            {
                Console.WriteLine($"{review.id} - rated {review.rating}, {review.body} by {review.username}");
            }
        }

        private void SearchRestaurant()
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

        private void Quit()
        {
            _isRunning = false;
        }

        private void RemoveRestaurant()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = int.Parse(Console.ReadLine());
            //Remove restaurant
            Restaurant r = crud.GetRestaurant(id);
            crud.RemoveRestaurant(r);
            Console.WriteLine($"Removed: {r.name}");
        }

        private string Menu()
        {
            return $"Menu:\n" +
                   $"L) List All Restaurants DESC\n" +
                   $"M) List All Restaurants ASC\n" +
                   $"P) Print Restaurant\n" +
                   $"R) Print Reviews\n" +
                   $"S) Search Restaurants\n" +
                   $"Q) Quit";
        }

        private void CallCommands(string input)
        {
            switch (input)
            {
                case "L":
                    PrintRestaurantsDESC();
                    break;
                case "M":
                    PrintRestaurantsASC();
                    break;
                case "P":
                    PrintRestaurant();
                    break;
                case "R":
                    PrintReviews();
                    break;
                case "S":
                    SearchRestaurant();
                    break;
                case "Q":
                    Quit();
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
        }

        public void Run()
        {
            Console.WriteLine($"Welcome to BadReviews!");
            Console.WriteLine(Menu());
            while (_isRunning)
            {
                try
                {
                    Console.Write($"\nEnter command: ");
                    string input = Console.ReadLine().ToUpper();
                    Console.WriteLine();
                    CallCommands(input);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        

        static void Main(string[] args)
        {
           RestaurantApp app = new RestaurantApp();
            app.Run();
        }
    }
}