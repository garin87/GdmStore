using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.DTO
{
    public class ProductOrderDTO
    {
        public string Number { get; set; }
        public string Manufacturer { get; set; }
        public string NameType { get; set; }
        public double PrimeCostEUR { get; set; }
    }
}
