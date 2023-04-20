namespace AnnonsWebAPI.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal? Price { get; set; }
        public DateTime? DatePosted { get; set; }
        public bool? IsActive { get; set; }
    }
}
