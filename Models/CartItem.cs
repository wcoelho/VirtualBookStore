using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VBSApi.Models
{
    public class CartItem
    {
        [Key]
        public long  CartId { get; set; }
        
        public string Status { get; set; }

        public ICollection<BookItem> BookItems { get; set; }

    }
}