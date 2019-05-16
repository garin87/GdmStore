using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> User { get; set; } = new List<User>();
      
    }
}
