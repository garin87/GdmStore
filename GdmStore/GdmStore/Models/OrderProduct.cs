using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Models
{
    public class OrderProduct
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int OrderId { get; set; }
        public virtual Orders Orders { get; set; }

        public double Amount { get; set; }
    }
}
