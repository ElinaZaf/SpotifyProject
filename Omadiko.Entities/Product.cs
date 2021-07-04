using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Omadiko.Entities.Custom_Validations;

namespace Omadiko.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Title is required")]
        [MaxLength(60,ErrorMessage ="Title must be less than 60 characters")]
        [MinLength(2,ErrorMessage ="Title must be greater than 2 characters")]
        public string Name { get; set; }

        [CustomValidation(typeof(ValidationMethods), Methods.ValidateGreaterThanZero)]
        public double Price { get; set; }
    }
}
