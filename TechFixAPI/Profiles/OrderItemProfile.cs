using AutoMapper;
using TechFixAPI.DTO;
using TechFixAPI.Model;

namespace TechFixAPI.Profiles
{
    public class OrderItemProfile:Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, ReadOrderItemDTO>();
            CreateMap<CreateOrderItemDTO, OrderItem>();
        }
    }
}
