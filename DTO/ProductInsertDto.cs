﻿using System;

namespace DTO
{
    public class ProductInsertDto
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string CodeSKU { get; set; }

        public int CategoryId { get; set; }


        public int SubCategoryId { get; set; }


        public string Thumbnail { get; set; }

        public string MainPhoto { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Price { get; set; }

        public string Featured { get; set; }
    }
}
