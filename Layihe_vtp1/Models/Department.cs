using System;
using System.Collections.Generic;

namespace Layihe_vtp1.Models
{
    public partial class Department
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? DepName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
