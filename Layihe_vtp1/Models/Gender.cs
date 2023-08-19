using System;
using System.Collections.Generic;

namespace Layihe_vtp1.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? GenderName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
