using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Models
{
    public class Parameter //: BaseObject
    {
        public int ParameterId { get; set; }
        public string Name { get; set; }

        [ForeignKey("ProductTypeId")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public ICollection<ProductParameter> ProductParameters { get; set; } = new List<ProductParameter>();
    }
}
