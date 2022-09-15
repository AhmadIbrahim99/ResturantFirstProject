using AutoMapper;
using ResturantFirstProject.Models;
using ResturantFirstProject.ViewModel;

namespace ResturantFirstProject.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RestaurantMenu, ResturantMenuVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<Restaurant, ResturntVM>().ReverseMap();
        }
    }
}
