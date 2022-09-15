using Microsoft.EntityFrameworkCore;
using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Extentions;
using ResturantFirstProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantFirstProject.Services
{
    public class ResturantMenuService : Repo<RestaurantMenu> , IResturantMenuService 
    {
        private readonly ResturantDBContext _context;
        public ResturantMenuService(ResturantDBContext context) : base(context)
        {
            _context = context;
        }
        public override Task Add(RestaurantMenu entity)
        {
            entity.PriceInUsd = Math.Round(entity.PricieInNis / CapitalizeExtention.FromNIStoUSD, 2);
            return base.Add(entity);
        }
        public override Task Update(int id, RestaurantMenu entity)
        {
            entity.PriceInUsd = Math.Round(entity.PricieInNis / CapitalizeExtention.FromNIStoUSD,2);
            return base.Update(id, entity);
        }
        public async Task<bool> isAvailable(int id)
        {
            
          var result = await _context.RestaurantMenus.FirstOrDefaultAsync(x=> x.Id == id);
            if (result == null)
                return false;

          return  result.Quantity > 0;
        }
    }
}
