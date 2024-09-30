using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechFixAPI.Data;
using TechFixAPI.DTO;
using TechFixAPI.Model;

namespace TechFixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepo repo;
        private readonly IMapper mapper;

        public OrderController(OrderRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateOrder(CreateOrderDTO create)
        {
            try
            {
                var model = mapper.Map<Order>(create);
                if (repo.CreateOrder(model))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<ReadOrderDTO> GetOrderByID(int id)
        {
            try
            {
                var Order = repo.GetOrderByID(id);
                if (Order != null)
                    return Ok(mapper.Map<ReadOrderDTO>(Order));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get orders by supplier id
        [HttpGet("supplier/{id}")]
        public ActionResult<IEnumerable<ReadOrderDTO>> GetOrdersBySupplierID(int id)
        {
            try
            {
                var Orders = repo.GetOrdersBySupplierID(id);
                if (Orders != null)
                    return Ok(mapper.Map<IEnumerable<ReadOrderDTO>>(Orders));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder
            (CreateOrderDTO create, int id)
        {
            try
            {
                var model = mapper.Map<Order>(create);
                model.Id = id;
                if (repo.UpdateOrder(model))
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
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                var model = repo.GetOrderByID(id);
                if (model != null)
                {
                    repo.DeleteOrder(model);
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
        public ActionResult<IEnumerable<ReadOrderDTO>> GetOrders()
        {
            try
            {
                var Inventories = repo.GetOrders();
                return Ok(mapper.Map<IEnumerable<ReadOrderDTO>>(Inventories));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
