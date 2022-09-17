using ResturantFirstProject.BaseRepo;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResturantFirstProject.Models
{
    public partial class Order : IBase
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public int IdResturantMenu { get; set; }
        public int IdCustomer { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Archived { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual RestaurantMenu IdResturantMenuNavigation { get; set; }
    }
}
