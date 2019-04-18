using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VBSApi.Models
{
    public class CartItem
    {
        [Key]
        public long  CartId { get; set; }
        
        public string Status { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public ICollection<BookItem> BookItems { get; set; }

    }
}