using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Models;

namespace ResturantFirstProject.Services
{
    public class OrderService : Repo<Order>, IOrderService
    {
        public OrderService(ResturantDBContext context) : base(context)
        {
        }
    }
}
