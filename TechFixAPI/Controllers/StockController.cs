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
        public ActionResult CreateStock(CreateStockDTO create)
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
        public ActionResult UpdateStock
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
        public ActionResult DeleteStock(int id)
        {
            try
            {
                var model = repo.GetStockByID(id);
                if (model != null)
                {
                    repo.DeleteStock(model);
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
        public ActionResult<IEnumerable<ReadStockDTO>> GetStocks()
        {
            try
            {
                var Stocks = repo.GetStocks();
                return Ok(mapper.Map<IEnumerable<ReadStockDTO>>(Stocks));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
