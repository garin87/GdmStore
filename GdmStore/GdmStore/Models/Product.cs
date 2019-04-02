using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GdmStore.Models
{
    public class Product //: BaseObject
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }
        public double Amount { get; set; }
        public double PrimeCostEUR { get; set; }

        [ForeignKey("ProductTypeId")]
        public int  ProductTypeId {  get; set; }
        public virtual ProductType ProductType { get; set; }

        public ICollection<ProductParameter> ProductParameters { get; set; } = new List<ProductParameter>();
    }
}
