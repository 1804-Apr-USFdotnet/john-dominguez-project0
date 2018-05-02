using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Data
{
    public partial class Restaurant
    {
        public static object Library { get; private set; }

        public double AvgRating()
        {
            double sum = this.Reviews.ToList().Sum(x => x.rating);
            return sum / this.Reviews.Count;
        }

        public List<Review> GetReviews()
        {
            return this.Reviews.ToList();
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

        public override string ToString()
        {
            return $"{id}:{name} | {AvgRating()} Stars | {Reviews.Count} Total Reviews";
        }

        public string ToStringExtended()
        {
            string s = $"{id}:{name} | {AvgRating()} Stars | {Reviews.Count} Total Reviews";
            s += "\n\t" + string.Join("\n\t", Reviews);
            return s;
        }
    }
}
