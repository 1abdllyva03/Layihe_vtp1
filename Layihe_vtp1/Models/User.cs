using System;
using System.Collections.Generic;

namespace Layihe_vtp1.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? University { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public short? Age { get; set; }
        public int? DepId { get; set; }
        public int? StatusId { get; set; }
        public int? GenderId { get; set; }

        public virtual Department? Dep { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual Status? Status { get; set; }
    }
}
