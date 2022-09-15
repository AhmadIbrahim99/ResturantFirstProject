using ResturantFirstProject.BaseRepo;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResturantFirstProject.Models
{
    public partial class Customer : IBase
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public bool Archived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
