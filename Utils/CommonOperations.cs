using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using VBSApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Formatting;
using System.IO;

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

        public static bool ValidateUser(long userId, string userName, string password)
        {

       
            var request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/v1/Authentication");

            // Make server accept request without certified
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            string stringData = 
            "{\"Id\":" + userId + ",\"UserName\": \""+ userName + "\",\"Password\": \"" + password + "\"}";

            var resultJson = JsonConvert.SerializeObject(stringData);

            var data = Encoding.ASCII.GetBytes(stringData); // or UTF8

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            var newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            string result = "";  

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)  
            {  
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());  
    
                // Read the whole contents and return as a string  
                result = reader.ReadToEnd();  
            }  

            var details = JObject.Parse(result);
            return (bool) details.GetValue("result");
        }
    
    }    
    
}
