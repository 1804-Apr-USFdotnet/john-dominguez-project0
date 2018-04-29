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
                var restaurants = crud.ShowAllRestaurants();
                foreach (var restaurant in restaurants)
                {
                    Console.WriteLine($"{restaurant.name}");
                }
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