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
    public class InventoryController : ControllerBase
    {
        private readonly InventoryRepo repo;
        private readonly IMapper mapper;

        public InventoryController(InventoryRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateInventory(CreateInventoryDTO create)
        {
            try
            {
                var model = mapper.Map<Inventory>(create);
                if (repo.CreateInventory(model))
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
        public ActionResult UpdateInventory
            (CreateInventoryDTO create, int id)
        {
            try
            {
                var model = mapper.Map<Inventory>(create);
                model.Id = id;
                if (repo.UpdateInventory(model))
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
        public ActionResult DeleteInventory(int id)
        {
            try
            {
                var model = repo.GetInventoryByID(id);
                if (model != null)
                {
                    repo.DeleteInventory(model);
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
        public ActionResult<IEnumerable<ReadInventoryDTO>> GetInventories()
        {
            try
            {
                var Inventories = repo.GetInventories();
                return Ok(mapper.Map<IEnumerable<ReadInventoryDTO>>(Inventories));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
