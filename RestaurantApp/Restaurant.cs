using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    class Restaurant
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public List<Review> Reviews { get; set; }

        public Restaurant(string name, string location)
        {
            Name = name;
            Location = location;
            Rating = 0;
            Reviews = new List<Review>();
        }

        public double AvgRating()
        {
            return Reviews.Sum(x => x.Rating);
        }

        public bool AddReview(Review review)
        {
            if (review == null) return false;
            Reviews.Add(review);
            return true;
        }

        public static List<Restaurant> TopThree(List<Restaurant> restaurants)
        {
            if (restaurants is null) throw new Exception("List can't be empty");
            return (List<Restaurant>) restaurants.OrderBy(x => x.AvgRating()).Reverse().ToList().Take(3);
        }

        public static List<Restaurant> Search(List<Restaurant> restaurants, string term)
        {
            if (restaurants is null) throw new Exception("List can't be empty");
            List<Restaurant> match = restaurants.FindAll(x => x.Equals(term));
            return match;
        }
    }
}
