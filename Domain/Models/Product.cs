using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_Id { get; set; }

        [Required, StringLength(20, ErrorMessage = "Product Name should be less than 20")]
        public string ProductName { get; set; }

        [Required, StringLength(100, ErrorMessage = "Product Name should be less than 100")]
        public string ProductDescription { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }
        public Category category { get; set; }


    }
}
