﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FinalPractice.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Code Product")]
        public string CodeSKU { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public CategoryViewModel Category { get; set; }

        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }

        [Display(Name = "SubCategory")]
        public SubCategoryViewModel SubCategory { get; set; }

        public string Thumbnail { get; set; }


        [Display(Name = "Main Photo")]
        public string MainPhoto { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Featured { get; set; }
        //public int? Id { get; set; }

        //public string Name { get; set; }

        //public string CodeSKU { get; set; }

        //public int CategoryId { get; set; }
        //public string Category { get; set; }

        //public int SubCategoryId { get; set; }
        //public string SubCategory { get; set; }

        //public string Thumbnail { get; set; }

        //public string MainPhoto { get; set; }

        //public string Summary { get; set; }

        //public string Description { get; set; }

        //public DateTime StartDate { get; set; }

        //public decimal Price { get; set; }

        //public string Featured { get; set; }
    }
}