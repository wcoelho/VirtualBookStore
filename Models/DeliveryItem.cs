using System.Collections.Generic;

namespace VBSApi.Models
{
    public class DeliveryItem
    {
        public long  DeliveryId { get; set; }

        public string Status { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}