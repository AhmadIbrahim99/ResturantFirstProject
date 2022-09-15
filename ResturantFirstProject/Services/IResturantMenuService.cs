using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Models;
using System.Threading.Tasks;

namespace ResturantFirstProject.Services
{
    public interface IResturantMenuService : IRepo<RestaurantMenu>
    {
        Task<bool> isAvailable(int id);
    }
}
