using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using library;

namespace RestaurantApp
{
    public class Restaurant : IComparable
    {
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

        public string Name { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public List<Review> Reviews { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherRestaurant = obj as Restaurant;
            if (otherRestaurant != null)
                return Rating.CompareTo(otherRestaurant.Rating);
            throw new ArgumentException("Object is not a Restaurant");
        }

        public double AvgRating()
        {
            double sum = Reviews.Sum(x => x.Rating);
            return sum / Reviews.Count;
        }

        public bool AddReview(Review review)
        {
            if (review == null) return false;
            Reviews.Add(review);
            return true;
        }

        public Review RemoveReview(int id)
        {
            if (id < 0) throw new InvalidDataException("Id Cannot be negative!");
            var removedReview = Reviews.Find(r => r.Id.Equals(id));
            Rating = (Rating - removedReview.Rating) / 2;
            return removedReview;
        }

        public static List<Restaurant> TopThree(List<Restaurant> restaurants)
        {
            if (restaurants == null) throw new Exception("List can't be empty");
            return CollectionLib.SortDescending(restaurants).Take(3).ToList();
        }

        public static List<Restaurant> Search(List<Restaurant> restaurants, string keyword)
        {
            if (restaurants == null) throw new Exception("List can't be empty");
            return restaurants.FindAll(x => x.Name.IndexOf(keyword, StringComparison.Ordinal) > 0);
        }

        public string AllReviews()
        {
            return string.Join(",", Reviews);
        }

        public override string ToString()
        {
            return $"{Name}@{Rating}\n\tReviews:[{AllReviews()}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var otherRestaurant = obj as Restaurant;

            return Name.Equals(otherRestaurant.Name)
                   & Location.Equals(otherRestaurant.Location)
                   & Rating.Equals(otherRestaurant.Rating)
                   & Reviews.Equals(otherRestaurant.Reviews);
        }

        // Factory Methods
        public static List<Restaurant> MakeRestaurants()
        {
            return new List<Restaurant>
            {
                new Restaurant("McDeath", "South of L", Review.MakeReviews()),
                new Restaurant("test2", "South of L", Review.MakeReviews()),
                new Restaurant("test3", "South of L", Review.MakeReviews()),
                new Restaurant("test4", "South of L", Review.MakeReviews())
            };
        }
    }
}