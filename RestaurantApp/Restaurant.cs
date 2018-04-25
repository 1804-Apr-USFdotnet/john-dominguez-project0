using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library;

namespace RestaurantApp
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public List<Review> Reviews { get; set; }

        public Restaurant()
        {
        }

        public Restaurant(string name, string location)
        {
            Name = name;
            Location = location;
            Rating = 0;
            Reviews = new List<Review>();
        }

        public Restaurant(string name, string location, List<Review> reviews) : this(name, location)
        {
            Reviews = reviews;
            Rating = AvgRating();
        }

        public double AvgRating()
        {
            return Reviews.Sum(x => x.Rating) / Reviews.Count;
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

        public static List<Restaurant> Search(List<Restaurant> restaurants, string keyword)
        {
            if (restaurants is null) throw new Exception("List can't be empty");
            return restaurants.FindAll(x => x.Name.IndexOf(keyword) > 0);
        }

        public string ToString()
        {
            return $"{Name}, {Rating}";
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Restaurant otherRestaurant = obj as Restaurant;
        
            return this.Name.Equals(otherRestaurant.Name)
                   & this.Location.Equals(otherRestaurant.Location)
                   & this.Rating.Equals(otherRestaurant.Rating)
                   & this.Reviews.Equals(otherRestaurant.Reviews);
        }

        // Factory Methods
        public static List<Restaurant> MakeRestaurants()
        {
            return new List<Restaurant>()
            {
                new Restaurant("McDeath", "South of L", Review.MakeReviews()),
                new Restaurant("test2", "South of L", Review.MakeReviews()),
                new Restaurant("test3", "South of L", Review.MakeReviews()),
                new Restaurant("test4", "South of L", Review.MakeReviews())
            };
        }
    }
}
