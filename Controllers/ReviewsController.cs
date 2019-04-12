using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VBSApi.Models;

namespace VBSApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly VBSContext _context;

        public ReviewsController(VBSContext context)
        {
            _context = context;           
        }

        // GET: api/v1/reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewItem>>> GetReviewItems()
        {
            return await _context.ReviewItems.ToListAsync();
        }

        // GET: api/v1/reviews/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewItem>> GetReviewItem(long id)
        {
            var ReviewItem = await _context.ReviewItems.FindAsync(id);

            if (ReviewItem == null)
            {
                return NotFound();
            }

            return ReviewItem;
        }

        // POST: api/v1/reviews
        [HttpPost]
        public async Task<ActionResult<ReviewItem>> PostReviewItem(ReviewItem review)
        {
            if (review == null)
            {
                throw new System.ArgumentNullException(nameof(review));
            }

            var bookItem = await _context.BookItems.FindAsync(review.BookItem.BookId);            

            if (bookItem == null)
            {
                return NotFound();
            }

            review.BookItem = bookItem;

            _context.ReviewItems.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviewItem), new { id = review.ReviewId }, review);
        }

        // PUT: api/v1/reviews/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ReviewItem>> PutReviewItem(long id, ReviewItem review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.ReviewItems.FindAsync(id);;
        }

        // DELETE: api/v1/reviews/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewItem(long iD)
        {
            var ReviewItem = await _context.ReviewItems.FindAsync(iD);

            if (ReviewItem == null)
            {
                return NotFound();
            }

            _context.ReviewItems.Remove(ReviewItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }  


}