using AutoMapper;
using TechFixAPI.DTO;
using TechFixAPI.Model;

namespace TechFixAPI.Profiles
{
    public class QuotationitemProfile:Profile
    {
        public QuotationitemProfile()
        {
            CreateMap<QuotationItem, ReadQuotationItemDTO>();
            CreateMap<CreateQuotationItemDTO, QuotationItem>();
        }
    }
}
