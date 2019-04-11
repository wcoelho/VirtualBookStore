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
    public class DeliveriesController : ControllerBase
    {
        private readonly VBSContext _context;

        public DeliveriesController(VBSContext context)
        {
            _context = context;           
        }

        // GET: api/v1/deliveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryItem>>> GetDeliveryItems()
        {
            return await _context.DeliveryItems.ToListAsync();
        }

        // GET: api/v1/deliveries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryItem>> GetDeliveryItem(long id)
        {
            var DeliveryItem = await _context.DeliveryItems.FindAsync(id);

            if (DeliveryItem == null)
            {
                return NotFound();
            }

            return DeliveryItem;
        }

        // POST: api/v1/deliveries
        [HttpPost]
        public async Task<ActionResult<DeliveryItem>> PostDeliveryItem(DeliveryItem delivery)
        {
            _context.DeliveryItems.Add(delivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeliveryItem), new { DeliveryId = delivery.DeliveryId }, delivery);
        }

        // PUT: api/v1/deliveries/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryItem>> PutDeliveryItem(long id, DeliveryItem delivery)
        {
            if (id != delivery.DeliveryId)
            {
                return BadRequest();
            }

            _context.Entry(delivery).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.DeliveryItems.FindAsync(id);;
        }

        // DELETE: api/v1/deliveries/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryItem(long iD)
        {
            var DeliveryItem = await _context.DeliveryItems.FindAsync(iD);

            if (DeliveryItem == null)
            {
                return NotFound();
            }

            _context.DeliveryItems.Remove(DeliveryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }  


}