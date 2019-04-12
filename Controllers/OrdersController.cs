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
    public class OrdersController : ControllerBase
    {
        private readonly VBSContext _context;

        public OrdersController(VBSContext context)
        {
            _context = context;           
        }

        // GET: api/v1/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/v1/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(long id)
        {
            var OrderItem = await _context.OrderItems.FindAsync(id);

            if (OrderItem == null)
            {
                return NotFound();
            }

            return OrderItem;
        }

        // POST: api/v1/orders
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem order)
        {
            if (order == null)
            {
                throw new System.ArgumentNullException(nameof(order));
            }
            
            var cartItem = await _context.CartItems.FindAsync(order.CartItem.CartId);

            if (cartItem == null)
            {
                return NotFound();
            }

            order.CartItem = cartItem;
            order.Status = "inprogress";

            _context.OrderItems.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderItem), new { id = order.OrderId }, order);
        }

        // PUT: api/v1/orders/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItem>> PutOrderItem(long id, OrderItem order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.OrderItems.FindAsync(id);;
        }

        // DELETE: api/v1/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(long iD)
        {
            var OrderItem = await _context.OrderItems.FindAsync(iD);

            if (OrderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(OrderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }  


}