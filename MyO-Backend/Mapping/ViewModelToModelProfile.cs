using AutoMapper;
using MyO_Backend.Models;
using MyO_Backend.ViewModels;

namespace MyO_Backend.Mapping
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<OrderDetailViewModel, OrderDetail>();
        }
    }
}
