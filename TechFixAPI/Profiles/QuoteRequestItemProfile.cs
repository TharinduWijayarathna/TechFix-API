using AutoMapper;
using TechFixAPI.DTO;
using TechFixAPI.Model;

namespace TechFixAPI.Profiles
{
    public class QuoteRequestItemProfile:Profile
    {
        public QuoteRequestItemProfile()
        {
            CreateMap<QuoteRequestItem, ReadQuoteRequestItemDTO>();
            CreateMap<CreateQuoteRequestItemDTO, QuoteRequestItem>();
        }
    }
}
