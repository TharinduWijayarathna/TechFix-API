using AutoMapper;
using CompanyAPI.Model;
using CompanyAPI.DTO;


namespace CompanyAPI.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ReadProductDTO>();
            CreateMap<CreateProdcutDTO, Product>();
        }
    }
}
