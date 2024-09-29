using AutoMapper;
using TechFixAPI.DTO;
using TechFixAPI.Model;

namespace TechFixAPI.Profiles
{
    public class QuoteRequestProfile:Profile
    {
        public QuoteRequestProfile()
        {
            CreateMap<QuoteRequest, ReadQuoteRequestDTO>();
            CreateMap<CreateQuoteRequestDTO, QuoteRequest>();
        }
    }
}
