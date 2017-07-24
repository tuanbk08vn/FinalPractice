using System;
using System.ComponentModel.DataAnnotations;
using DomainLayer.Models;

namespace FinalPractice.ViewModels
{
    public class ProductViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Code Product")]
        public string CodeSKU { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
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
    }
}