using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public abstract class Product
    {
        private double price;
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number")]
        [Required]
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be non-negative number!");
                }
                this.price = value;
            }
        }

        [Required]
        public string AccuiredOn { get; set; }

        [Required]
        public string DateOfExpiry { get; set; }


    }
}
