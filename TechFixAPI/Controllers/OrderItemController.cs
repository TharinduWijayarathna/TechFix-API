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
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemRepo repo;
        private readonly IMapper mapper;

        public OrderItemController(OrderItemRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateOrderItem(CreateOrderItemDTO create)
        {
            try
            {
                var model = mapper.Map<OrderItem>(create);
                if (repo.CreateOrderItem(model))
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
        public ActionResult<ReadOrderItemDTO> GetOrderItemByID(int id)
        {
            try
            {
                var OrderItem = repo.GetOrderItemByID(id);
                if (OrderItem != null)
                    return Ok(mapper.Map<ReadOrderItemDTO>(OrderItem));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderItem
            (CreateOrderItemDTO create, int id)
        {
            try
            {
                var model = mapper.Map<OrderItem>(create);
                model.Id = id;
                if (repo.UpdateOrderItem(model))
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
        public ActionResult DeleteOrderItem(int id)
        {
            try
            {
                var model = repo.GetOrderItemByID(id);
                if (model != null)
                {
                    repo.DeleteOrderItem(model);
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
        public ActionResult<IEnumerable<ReadOrderItemDTO>> GetOrderItems()
        {
            try
            {
                var Inventories = repo.GetOrderItems();
                return Ok(mapper.Map<IEnumerable<ReadOrderItemDTO>>(Inventories));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
