using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MyO_Backend.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
