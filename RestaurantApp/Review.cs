using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    class Review
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
    }
}
