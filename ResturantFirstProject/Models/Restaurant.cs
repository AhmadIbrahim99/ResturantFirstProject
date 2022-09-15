using ResturantFirstProject.BaseRepo;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResturantFirstProject.Models
{
    public partial class Restaurant : IBase
    {
        public Restaurant()
        {
            RestaurantMenus = new HashSet<RestaurantMenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<RestaurantMenu> RestaurantMenus { get; set; }
    }
}
