using AutoMapper;
using TechFixAPI.Model;
using TechFixAPI.DTO;


namespace TechFixAPI.Profiles
{
    public class StockProfile:Profile
    {
        public StockProfile()
        {
            CreateMap<Stock,ReadStockDTO>();
            CreateMap<CreateStockDTO, Stock>();
        }
    }
}
