using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Models;

namespace ResturantFirstProject.Services
{
    public class ResturantService : Repo<Restaurant>, IResturantService
    {
        public ResturantService(ResturantDBContext context) : base(context)
        {
        }
    }
}
