using ResturantFirstProject.BaseRepo;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResturantFirstProject.Models
{
    public partial class RestaurantMenu : IBase
    {
        public RestaurantMenu()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string MealName { get; set; }
        public bool Archived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public double PricieInNis { get; set; }
        public double PriceInUsd { get; set; }
        public int Quantity { get; set; }
        public int IdRestaurant { get; set; }

        public virtual Restaurant IdRestaurantNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
