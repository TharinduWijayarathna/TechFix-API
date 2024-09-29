using AutoMapper;
using TechFixAPI.DTO;
using TechFixAPI.Model;

namespace TechFixAPI.Profiles
{
    public class QuotationProfile:Profile
    {
        public QuotationProfile()
        {
            CreateMap<Quotation, ReadQuotationDTO>();
            CreateMap<CreateQuotationDTO, Quotation>();
        }
    }
}
