using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewsWebApi.Data;

namespace ReviewsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly DataContext _context;

        public ReviewsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> Get()
        {
            return Ok(await _context.Reviews.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> Get(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
                return BadRequest("Review not found.");

            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<List<Review>>> AddReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Ok(await _context.Reviews.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Review>>> UpdateReview(Review request)
        {
            var dbReview = await _context.Reviews.FindAsync(request.ReviewId);

            if (dbReview == null)
                return BadRequest("Review not found.");

            dbReview.Rating = request.Rating;
            dbReview.Content = request.Content;
            dbReview.Title = request.Title;

            await _context.SaveChangesAsync();

            return Ok(await _context.Reviews.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Review>>> Delete(int id)
        {
            var dbReview = await _context.Reviews.FindAsync(id);

            if (dbReview == null)
                return BadRequest("Review not found.");

            _context.Reviews.Remove(dbReview);
            await _context.SaveChangesAsync();

            return Ok(await _context.Reviews.ToListAsync());
        }


    }
}
