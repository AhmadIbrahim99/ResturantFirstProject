using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Models;

namespace ResturantFirstProject.Services
{
    public class CustomerService : Repo<Customer>, ICustomerService
    {
        public CustomerService(ResturantDBContext context) : base(context)
        {
        }
    }
}
