using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Models
{
    public class ProductType //: BaseObject
    {   
        public int Id { get; set; }

        public string NameType { get; set; }
      
        public ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
