using System.Collections.Generic;

namespace VBSApi.Models
{
    public class CartItem
    {
        public long  CartId { get; set; }
        
        public string Status { get; set; }

        public ICollection<BookItem> BookItems { get; set; }

    }
}