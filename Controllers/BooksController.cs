﻿using Microsoft.AspNetCore.Mvc;
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
    public class BooksController : ControllerBase
    {
        private readonly VBSContext _context;

        public BooksController(VBSContext context)
        {
            _context = context;

            if (_context.BookItems.Count() == 0)
            {
                // Populates a initial list of books
                CommonOperations.AddBooks(_context);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookItem>>> GetBookItems()
        {
            return await _context.BookItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookItem>> GetBookItem(long id)
        {
            var BookItem = await _context.BookItems.FindAsync(id);

            if (BookItem == null)
            {
                return NotFound();
            }

            return BookItem;
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookItem>> PostBookItem(BookItem book)
        {
            if (book == null)
            {
                throw new System.ArgumentNullException(nameof(book));
            }

            _context.BookItems.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookItem), new { id = book.BookId }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<BookItem>> PutBookItem(long id, BookItem book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.BookItems.FindAsync(id);;
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookItem(long id)
        {
            var BookItem = await _context.BookItems.FindAsync(id);

            if (BookItem == null)
            {
                return NotFound();
            }

            _context.BookItems.Remove(BookItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }  


}