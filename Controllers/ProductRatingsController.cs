using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Rating.Models;

namespace Rating.Controllers
{
    public class ProductRatingsController : ApiController
    {
        private RatingContext db = new RatingContext();

        // GET: api/ProductRatings
        public IQueryable<ProductRating> GetProductRatings()
        {
            return db.ProductRatings;
        }

        // GET: api/ProductRatings/5
        [HttpGet]
        [ActionName("ProductRating")]
        [ResponseType(typeof(ProductRating))]
        public IHttpActionResult GetProductRating(int id)
        {
            IQueryable<ProductRating> productRatings = db.ProductRatings.Where(Rating=>Rating.ProductId == id);
            if (productRatings.Count()==0)
            {
                return NotFound();
            }

            return Ok(productRatings);
        }

        // GET: api/ProductRatings/5
        [HttpGet]
        [ActionName("ProductRatingByCustomer")]
        [ResponseType(typeof(ProductRating))]
        public IHttpActionResult ProductRatingByCustomer(int productId,int userId)
        {
            IQueryable<ProductRating> productRatings = db.ProductRatings.Where(Rating => Rating.ProductId == productId && Rating.UserId == userId);
            if (productRatings.Count() == 0)
            {
                return NotFound();
            }

            return Ok(productRatings.FirstOrDefault());
        }

        // GET: api/AverageProductRatings/5
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
                if (db.ProductRatings.Count(e => e.ProductId == productId && e.UserId == userId)==0)
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
        [HttpPost]
        [ActionName("PostProductRating")]
        [ResponseType(typeof(ProductRating))]
        public IHttpActionResult PostProductRating(ProductRating productRating)
        {
           IQueryable<ProductRating> ifIdExists = db.ProductRatings.AsNoTracking().Where(x => x.ProductId == productRating.ProductId && x.UserId == productRating.UserId);

            if (ifIdExists.Count() != 0 )
            {
                productRating.RatingId = ifIdExists.FirstOrDefault().RatingId;
                return  PutProductRating(productRating.ProductId, productRating.UserId, productRating);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductRatingExists(int id)
        {
            return db.ProductRatings.Count(e => e.RatingId == id) > 0;
        }
    }
}