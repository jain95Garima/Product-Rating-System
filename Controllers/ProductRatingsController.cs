namespace Rating.Controllers
{
    using Rating.Models;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    /// <summary>
    /// Defines the <see cref="ProductRatingsController" />
    /// </summary>
    public class ProductRatingsController : ApiController
    {
        /// <summary>
        /// Defines the db
        /// </summary>
        private RatingContext db = new RatingContext();

        // GET: api/ProductRatings
        /// <summary>
        /// The GetProductRatings
        /// </summary>
        /// <returns>The <see cref="IQueryable{ProductRating}"/></returns>
        public IQueryable<ProductRating> GetProductRatings()
        {
            return db.ProductRatings;
        }

        // GET: api/ProductRatings/5
        /// <summary>
        /// The GetProductRating
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpGet]
        [ActionName("ProductRating")]
        [ResponseType(typeof(ProductRating))]
        public IHttpActionResult GetProductRating(int id)
        {
            IQueryable<ProductRating> productRatings = db.ProductRatings.Where(Rating => Rating.ProductId == id);
            if (productRatings.Count() == 0)
            {
                return NotFound();
            }

            return Ok(productRatings);
        }

        // GET: api/ProductRatings/5
        /// <summary>
        /// The ProductRatingByCustomer
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <param name="userId">The userId<see cref="int"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpGet]
        [ActionName("ProductRatingByCustomer")]
        [ResponseType(typeof(ProductRating))]
        public IHttpActionResult ProductRatingByCustomer(int productId, int userId)
        {
            IQueryable<ProductRating> productRatings = db.ProductRatings.Where(Rating => Rating.ProductId == productId && Rating.UserId == userId);
            if (productRatings.Count() == 0)
            {
                return NotFound();
            }

            return Ok(productRatings.FirstOrDefault());
        }

        // GET: api/AverageProductRatings/5
        /// <summary>
        /// The GetAverageProductRating
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpGet]
        [ActionName("AverageProductRating")]
        [ResponseType(typeof(ProductRating))]
        public IHttpActionResult GetAverageProductRating(int id)
        {
            IQueryable<ProductRating> productRatings = db.ProductRatings.Where(productRating => productRating.ProductId == id);


            if (productRatings.Count() == 0)
            {
                return NotFound();
            }

            var average = productRatings.Average(productRating => productRating.RatingGiven);

            return Ok(average);
        }

        // PUT: api/ProductRating/5/2
        /// <summary>
        /// The PutProductRating
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <param name="userId">The userId<see cref="int"/></param>
        /// <param name="productRating">The productRating<see cref="ProductRating"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpPut]
        [ActionName("PutProductRating")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductRating(int productId, int userId, ProductRating productRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (productId != productRating.ProductId && userId != productRating.UserId)
            {
                return BadRequest();
            }

            db.Entry(productRating).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (db.ProductRatings.Count(e => e.ProductId == productId && e.UserId == userId) == 0)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductRatings
        /// <summary>
        /// The PostProductRating
        /// </summary>
        /// <param name="productRating">The productRating<see cref="ProductRating"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpPost]
        [ActionName("PostProductRating")]
        [ResponseType(typeof(ProductRating))]
        public IHttpActionResult PostProductRating(ProductRating productRating)
        {
            IQueryable<ProductRating> ifIdExists = db.ProductRatings.AsNoTracking().Where(x => x.ProductId == productRating.ProductId && x.UserId == productRating.UserId);

            if (ifIdExists.Count() != 0)
            {
                productRating.RatingId = ifIdExists.FirstOrDefault().RatingId;
                return PutProductRating(productRating.ProductId, productRating.UserId, productRating);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductRatings.Add(productRating);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productRating.ProductId }, productRating);
        }

        // DELETE: api/ProductRatings/5
        /// <summary>
        /// The DeleteProductRating
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <param name="userId">The userId<see cref="int"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [ResponseType(typeof(ProductRating))]
        public IHttpActionResult DeleteProductRating(int productId, int userId)
        {
            IQueryable<ProductRating> productRating = db.ProductRatings.Where(x => x.ProductId == productId && x.UserId == userId);
            if (productRating == null)
            {
                return NotFound();
            }

            db.ProductRatings.Remove(productRating.FirstOrDefault());
            db.SaveChanges();

            return Ok(productRating);
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The ProductRatingExists
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool ProductRatingExists(int id)
        {
            return db.ProductRatings.Count(e => e.RatingId == id) > 0;
        }
    }
}
