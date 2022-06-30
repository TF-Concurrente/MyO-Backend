using AutoMapper;
using MyO_Backend.Models;
using MyO_Backend.Resources;

namespace MyO_Backend.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>()
                .ForMember(u => u.FullName, opt => opt
                .MapFrom(us => us.FirstName + " " + us.LastName));
        }
    }
}
