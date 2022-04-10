using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PackegedProduct : Product
    {
        [Required]
        public int NumberInStock { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
