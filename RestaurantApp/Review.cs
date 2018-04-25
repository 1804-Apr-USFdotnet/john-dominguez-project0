using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string ToString()
        {
            return $"";
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
            return new List<Review>()
            {
                new Review(3, "John"),
                new Review(7, "Manjot"),
                new Review(7, "Jake"),
                new Review(7, "Mit")
            };
        }
    }
}
