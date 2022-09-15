using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Models;
using System.Threading.Tasks;

namespace ResturantFirstProject.Services
{
    public interface IOrderService : IRepo<Order>
    {
        Task<bool> isAvailable(int id);
    }
}
