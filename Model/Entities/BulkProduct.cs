using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class BulkProduct : Product
    {
        [Required]
        public double Amount { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
