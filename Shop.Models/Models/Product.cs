using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Shop.Models.Models
{
    public class Product
    {
       

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title{ get; set; }

        [Required]
        public string? Desc { get; set; }

        [Required]
        public string? ISBN { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        [Display(Name = "Lista Ár")]
        [Range(1,10000)]
        public int ListPrice { get; set; }

        [Required]
        [Display(Name = "Lista Ár 1-50")]
        [Range(1, 10000)]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Lista Ár 50+")]
        [Range(1, 10000)]
        public int Price50 { get; set; }

        [Required]
        [Display(Name = "Lista Ár 100+")]
        [Range(1, 10000)]
        public int Price100 { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }  


    }
}
