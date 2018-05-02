using library;
using System;
using System.IO;

namespace RestaurantApp
{
    public class RestaurantApp
    {
        private static NLog.Logger logger;
        private bool _isRunning;

        public RestaurantApp()
        {
            _isRunning = true;
            logger = NLog.LogManager.GetCurrentClassLogger();
        }


        private void Quit()
        {
            NLog.LogManager.Shutdown();
            Console.WriteLine("Sayonara!");
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
                   $"T) Top Three Restaurants\n" +
                   $"X) Quit";
        }

        private void CallCommands(string input)
        {
            switch (input)
            {
                case "L":
                    RestaurantLibrary.PrintRestaurantsDesc();
                    break;
                case "M":
                    RestaurantLibrary.PrintRestaurantsAsc();
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
                case "T":
                    RestaurantLibrary.PrintTopThreeRestaurants();
                    break;
                case "Z":
                    RestaurantLibrary.SerializeDB();
                    break;
                case "X":
                    Quit();
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
        }

        public void Run()
        {
            RestaurantLibrary.DeserializeJSON();

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
                    logger.Info(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    logger.Error(e);
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