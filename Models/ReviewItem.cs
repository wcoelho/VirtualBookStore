using System.ComponentModel.DataAnnotations;
namespace VBSApi.Models
{
    public class ReviewItem
    {
        [Key]
        public long  ReviewId { get; set; }

        public BookItem BookItem { get; set; }

        public string Review { get; set; }

    }
}