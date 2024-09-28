using AutoMapper;
using TechFixAPI.DTO;
using TechFixAPI.Model;

namespace TechFixAPI.Profiles
{
    public class InventoryProfile:Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, ReadInventoryDTO>();
            CreateMap<CreateInventoryDTO, Inventory>();
        }
    }
}
