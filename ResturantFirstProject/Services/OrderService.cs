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
            return result.Quantity > 0;
        }
    }
}
