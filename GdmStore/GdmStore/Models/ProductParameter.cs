using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GdmStore.Models
{
    public class ProductParameter //: BaseObject
    {
        public int ProductParameterId { get; set; }

        public int ProductId { get; set; }
        public int ParameterId { get; set; }

        public Parameter Parameter { get; set; }
        public Product Product { get; set; }

        public string Value { get; set; }

    }

}
