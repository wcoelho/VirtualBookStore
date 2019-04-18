using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VBSApi.Models;
using VBSApi.Utils;

namespace VBSApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly VBSContext _context;

        public CartsController(VBSContext context)
        {
            _context = context;           
        }

        // GET: api/v1/carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.CartItems.ToListAsync();
        }

        // GET: api/v1/carts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(long id)
        {
            var CartItem = await _context.CartItems.FindAsync(id);

            if (CartItem == null)
            {
                return NotFound();
            }

            return CartItem;
        }

        // POST: api/v1/carts
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cart)
        {
            if (cart == null)
            {
                throw new System.ArgumentNullException(nameof(cart));
            }
            else if (cart.BookItems == null)
            {
                throw new System.ArgumentNullException(nameof(cart.BookItems));
            }

            // Validate user
            var userId = cart.UserId;
            var userName = cart.UserName;
            var password = cart.Password;

            // If validation fails, return bad request
            if(!CommonOperations.ValidateUser(userId, userName, password))
            {
                return BadRequest();
            }

            // Retrieving all books from cart            
            ICollection<BookItem> books = await CommonOperations.ExtractBooks(cart, _context);

            cart.BookItems = books;

            // Setting the initial status
            cart.Status = "open";

            _context.CartItems.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCartItem), new { id = cart.CartId }, cart);
        }

        // PUT: api/v1/carts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CartItem>> PutCartItem(long id, CartItem cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            // Validate user
            var userId = cart.UserId;
            var userName = cart.UserName;
            var password = cart.Password;

            // If validation fails, return bad request
            if(!CommonOperations.ValidateUser(userId, userName, password))
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.CartItems.FindAsync(id);;
        }

        // DELETE: api/v1/carts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(long iD)
        {
            var CartItem = await _context.CartItems.FindAsync(iD);

            if (CartItem == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(CartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }  


}