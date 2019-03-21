using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.DTO
{
    public class ProductDTO
    {   

        public int ProductId { get; set; }
        public string Number { get; set; }
        public double Amount { get; set; }
        public double PrimeCostEUR { get; set; }

        public int ProductTypeId { get; set; }
        public string NameType { get; set; }

        public int ParameterId { get; set; }
        public string Name { get; set; }

        public int ProductParameterId { get; set; }
        public string Value { get; set; }

    }
}
