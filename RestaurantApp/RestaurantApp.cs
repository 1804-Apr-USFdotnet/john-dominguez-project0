using library;
using System;

namespace RestaurantApp
{
    public class RestaurantApp
    {
        
        private bool _isRunning;

        public RestaurantApp()
        {
            _isRunning = true;
        }
       

        private void Quit()
        {
            _isRunning = false;
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
                    RestaurantLibrary.PrintRestaurantsDESC();
                    break;
                case "M":
                    RestaurantLibrary.PrintRestaurantsASC();
                    break;
                case "P":
                    RestaurantLibrary.PrintRestaurant();
                    break;
                case "R":
                    RestaurantLibrary.PrintReviews();
                    break;
                case "S":
                    RestaurantLibrary.SearchRestaurant();
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