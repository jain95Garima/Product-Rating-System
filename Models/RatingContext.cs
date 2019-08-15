namespace Rating.Models
{
    using System.Data.Entity;

    /// <summary>
    /// Defines the <see cref="RatingContext" />
    /// </summary>
    public class RatingContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        /// <summary>
        /// Initializes a new instance of the <see cref="RatingContext"/> class.
        /// </summary>
        public RatingContext() : base("name=RatingContext")
        {
        }

        /// <summary>
        /// Gets or sets the Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the ProductRatings
        /// </summary>
        public DbSet<ProductRating> ProductRatings { get; set; }
    }
}
