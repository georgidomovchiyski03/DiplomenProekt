using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Order
    {
        private double value;
        [Key]
        public int Id { get; set; }

        [Required]
        public string PlacedOn { get; set; }

        [Required]
        public string PlacedFor { get; set; }

        public ICollection<BulkProduct>? BulkProducts { get; set; }

        public ICollection<PackegedProduct>? PackegedProducts { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value must be a non-negative number")]
        [Required]
        public double Value
        {
            get
            {
                return value;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value must be non-negative number!");
                }
                this.value = value;
            }
        }
        
    }
}
