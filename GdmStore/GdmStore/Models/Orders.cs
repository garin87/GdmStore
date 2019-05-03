using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GdmStore.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public string NameCompany { get; set; }
        public int Price { get; set; }
        public DateTime DateTime{ get; set; }

        //public ICollection<OrderProduct> OrderProduct { get; set; } = new List<OrderProduct>();
    }
}
