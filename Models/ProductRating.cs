using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class ProductRating
    {
        [Key]
        public int RatingId { get; set; }  // need to remove.


        // Navigation property
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        // Navigation property
        public Product Product { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int RatingGiven { get; set; }

    }
}