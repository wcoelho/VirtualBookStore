using System.ComponentModel.DataAnnotations;
namespace VBSApi.Models
{
    public class OrderItem
    {
        [Key]
        public long  OrderId { get; set; }

        public CartItem  CartItem { get; set; }

        public double  Payment { get; set; }

        public string Status { get; set; }

    }
}