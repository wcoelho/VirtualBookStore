namespace VBSApi.Models
{
    public class BookItem
    {
        public long  ID { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Synopsis { get; set; }
        public double Value { get; set; }

    }
}