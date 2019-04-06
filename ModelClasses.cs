using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Core_ApiApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryRowId { get; set; }
        [Required(ErrorMessage = "Category Id is Required")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Base Price is Required")]
     //   [NumericNonNegative(ErrorMessage ="Base Price must be greater than 0")]
        public int BasePrice { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductRowId { get; set; }
        [Required(ErrorMessage ="Product Id is Required")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Category Row Id is Required")]
        public int CategoryRowId { get; set; }
        public Category Category { get; set; }
    }

    public class NumericNonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
