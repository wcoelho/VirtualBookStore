namespace VBSApi.Models
{
    public class ReviewItem
    {
        public long  ReviewId { get; set; }

        public BookItem BookItem { get; set; }

        public string Review { get; set; }

    }
}