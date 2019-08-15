namespace Rating.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ProductRating" />
    /// </summary>
    public class ProductRating
    {
        /// <summary>
        /// Gets or sets the RatingId
        /// </summary>
        [Key]
        public int RatingId { get; set; }

        // Navigation property
        /// <summary>
        /// Gets or sets the User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }

        // Navigation property
        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the RatingGiven
        /// </summary>
        public int RatingGiven { get; set; }
    }
}
