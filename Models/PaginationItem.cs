using System.ComponentModel.DataAnnotations;
namespace VBSApi.Models
{
    public class PaginationItem
    {
        [Key]
        public long Id { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total  { get; set; }

    }
}