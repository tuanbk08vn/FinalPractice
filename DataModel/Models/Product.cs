using System;

namespace DomainLayer.Models
{
    public class Product
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string CodeSKU { get; set; }

        public string CategoryId { get; set; }
        public string Category { get; set; }

        public string SubCategoryId { get; set; }
        public string SubCategory { get; set; }

        public string Thumbnail { get; set; }

        public string MainPhoto { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Price { get; set; }

        public string Featured { get; set; }
    }
}