using Microsoft.AspNetCore.Mvc;
using TechFixAPI.Model;
using TechFixAPI.DTO;
using TechFixAPI.Data;
using TechFixAPI.Profiles;
using AutoMapper;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly StockRepo repo;
        private readonly IMapper mapper;

        public StockController(StockRepo _repo, IMapper _mapper)
        { 
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateProduct(CreateStockDTO create)
        {
            try
            {
                var model=mapper.Map<Stock>(create);
                if (repo.CreateStock(model))
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
            (CreateStockDTO create,int id)
        {
            try
            {
                var model = mapper.Map<Stock>(create);
                model.Id = id;
                if (repo.UpdateStock(model))
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
        public ActionResult<IEnumerable<ReadStockDTO>> GetProducts()
        {
            try
            {
                var products = repo.GetProducts();
                return Ok(mapper.Map<IEnumerable<ReadStockDTO>>(products));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
