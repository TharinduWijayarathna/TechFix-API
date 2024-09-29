using AutoMapper;
using TechFixAPI.DTO;
using TechFixAPI.Model;

namespace TechFixAPI.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ReadOrderDTO>();
            CreateMap<CreateOrderDTO, Order>();
        }
    }
}
