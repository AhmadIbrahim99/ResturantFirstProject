using Microsoft.EntityFrameworkCore;
using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Models;
using System.Threading.Tasks;

namespace ResturantFirstProject.Services
{
    public class OrderService : Repo<Order>, IOrderService
    {
        private readonly ResturantDBContext _context;
        public OrderService(ResturantDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> isAvailable(int id)
        {
            var result = await _context.RestaurantMenus.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) return false;
            return result.Quantity > 0;
        }

        public override async Task Add(Order entity)
        {
            var menu = await _context.RestaurantMenus.SingleOrDefaultAsync(x=> x.Id == entity.IdResturantMenu );
            entity.TotalPrice = menu.PricieInNis * entity.Quantity;

            await base.Add(entity);
        }
    }
}
