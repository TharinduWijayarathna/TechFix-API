using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Model;
using CompanyAPI.DTO;
using CompanyAPI.Data;
using CompanyAPI.Profiles;
using AutoMapper;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductRepo repo;
        private readonly IMapper mapper;

        public ProductController(ProductRepo _repo, IMapper _mapper)
        { 
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateProduct(CreateProdcutDTO create)
        {
            try
            {
                var model=mapper.Map<Product>(create);
                if (repo.CreateProduct(model))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct
            (CreateProdcutDTO create,int id)
        {
            try
            {
                var model = mapper.Map<Product>(create);
                model.Id = id;
                if (repo.UpdateProduct(model))
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var model = repo.GetProductByID(id);
                if (model != null)
                {
                    repo.DeleteProduct(model);
                    return Ok();
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult<IEnumerable<ReadProductDTO>> GetProducts()
        {
            try
            {
                var products = repo.GetProducts();
                return Ok(mapper.Map<IEnumerable<ReadProductDTO>>(products));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
