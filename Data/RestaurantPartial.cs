using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public partial class Restaurant
    {
        public double Rating { get; set; }

        public double AvgRating()
        {
            double sum = this.Reviews.ToList().Sum(x => x.rating);
            return sum / this.Reviews.Count;
        }

        public static List<Restaurant> SearchRestaurants(List<Restaurant> restaurants, string keyword)
        {
            return restaurants.FindAll(x => x.name.ToUpper().Contains(keyword.ToUpper()));
        }

        public static List<Restaurant> SortAscending(List<Restaurant> list)
        {
            return (List<Restaurant>)list.OrderBy(i => i.AvgRating()).ToList();
        }

        public static List<Restaurant> SortDescending(List<Restaurant> list)
        {
            return (List<Restaurant>)list.OrderByDescending(i => i.AvgRating()).ToList();
        }
    }
}
