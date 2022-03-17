using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required, StringLength(20, ErrorMessage = "Product Name should be less than 20")]

        public string CategoryName { get; set; }

        [Required, StringLength(100, ErrorMessage = "Product Name should be less than 100")]

        public string CategoryDescription { get; set; }
    }
}
