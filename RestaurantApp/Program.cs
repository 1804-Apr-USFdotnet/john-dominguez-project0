using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Data;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantCrud crud = new RestaurantCrud();

            try
            {
                //Show all Restaurant
                var restaurants = crud.GetAllRestaurants();
//                foreach (var restaurant in restaurants)
//                {
//                    Console.WriteLine($"{restaurant.name}");
//                }

                //show restaurant
                var showRestaurant = crud.GetRestaurant(1);
                Console.WriteLine($"{showRestaurant.name}, {showRestaurant.Reviews.Count} Reviews");
                foreach (var r in showRestaurant.Reviews)
                {
                    Console.WriteLine($"\t{r.username} rated {r.rating}");
                }
                

                //Remove
//                for (int i = 10; i < 200; i++)
//                {
//                    Restaurant r = crud.GetRestaurant(i);
//                    crud.RemoveRestaurant(r);
//                    Console.WriteLine($"Removed: {r.name}");
//                }




                //
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}