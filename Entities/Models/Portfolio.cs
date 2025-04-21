namespace Entities.Models
{
    public class Portfolio:BaseEntity
    {
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Title { get; set; }
        public string ProjectUrl { get; set; }
        public string Description { get; set; }
        public int? PortfolioCategoryId { get; set; }
        public virtual PortfolioCategory PortfolioCategory { get; set; }
    }
}
