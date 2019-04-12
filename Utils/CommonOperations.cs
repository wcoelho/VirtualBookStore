using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VBSApi.Models;

namespace VBSApi.Utils
{
    public class CommonOperations
    {

        /*Populates book items*/
        public static void AddBooks(VBSContext context)
        {
            var isbn = "123456";
            var title = "This is the title of book #";
            var genres = new List<string>() {"male","female"};
            var synopsis = "This book is the book #";
            var value = 20;

            var books = new List<BookItem>();
            var pagination = new PaginationItem();
            pagination.Limit = 40;
            pagination.Offset = 20;
            pagination.Total = 1000;

            for(int i=0; i<10; i++)
            {
                // Select the genre according to current index
                var index = (i % 2)==0? 0 : 1;

                BookItem book = new BookItem() { 
                    Isbn = isbn+i,
                    Title = title+i,                    
                    Genre = genres[index],
                    Synopsis = synopsis+i,
                    Value = (long) value/(i+1),
                    Pagination = pagination                    
                };

                context.BookItems.Add(book);
            }

            context.SaveChanges();
        }
        
        /*Extracts book items from cart*/
        public async static Task<List<BookItem>> ExtractBooks(CartItem cart, VBSContext context)
        {
            var books = new List<BookItem>();

            foreach (var book in cart.BookItems)
            {
                var bookItem = await context.BookItems.FindAsync(book.BookId);
                if (bookItem == null)
                {
                    continue;
                }

                books.Add(bookItem);
            }

            return books;
        }
        
        /*Extracts order items from delivery*/
        public async static Task<List<OrderItem>> ExtractOrders(DeliveryItem delivery, VBSContext context)
        {
            var orders = new List<OrderItem>();

            foreach (var order in delivery.OrderItems)
            {
                var orderItem = await context.OrderItems.FindAsync(order.OrderId);
                if (orderItem == null)
                {
                    continue;
                }

                orders.Add(orderItem);
            }

            return orders;
        }
    }
}
