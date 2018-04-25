using System;
using System.Collections.Generic;
using library;
using Library;

namespace RestaurantApp
{
    public class Review
    {
        public static int TotalReviews = 0;
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public DateTime DateTime { get; set; }

        public Review(int rating, string author)
        {
            Rating = rating;
            Author = author;
            DateTime = DateTime.Now;
            TotalReviews++;
            Id = TotalReviews;
        }

        public override string ToString()
        {
            return $"{Rating}:{Author}";
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Review otherReview = obj as Review;

            return this.Rating.Equals(otherReview.Rating)
                   & this.Author.Equals(otherReview.Author)
                   & this.DateTime.Equals(otherReview.DateTime);
        }

        // Factory Methods
        public static List<Review> MakeReviews()
        {
            var rand = new Random();
            return new List<Review>()
            {
                new Review(CollectionLib.RandomRating(10), "John"),
                new Review(CollectionLib.RandomRating(10), "Manjot"),
                new Review(CollectionLib.RandomRating(10), "Jake"),
                new Review(CollectionLib.RandomRating(10), "Mit")
            };
        }
    }
}
