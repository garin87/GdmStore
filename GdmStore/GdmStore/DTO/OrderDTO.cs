using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }

        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Amount { get; set; }

    }
}
