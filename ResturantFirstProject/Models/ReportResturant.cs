using ResturantFirstProject.BaseRepo;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResturantFirstProject.Models
{
    public partial class ReportResturant 
    {
        public double? PriceInUsd { get; set; }
        public double? PricieInNis { get; set; }
        public string RestuarntName { get; set; }
        public string TheMostPurchasedCustomer { get; set; }
        public int ResturantId { get; set; }
        public int? TotalOrders { get; set; }
        public long? Rank { get; set; }
    }
}
