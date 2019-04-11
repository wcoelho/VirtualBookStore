using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VBSApi.Models
{
    public class DeliveryItem
    {
        [Key]
        public long  DeliveryId { get; set; }

        public string Status { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}