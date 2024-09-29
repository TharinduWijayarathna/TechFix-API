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
    public class QuotationItemController : ControllerBase
    {
        private readonly QuotationItemRepo repo;
        private readonly IMapper mapper;

        public QuotationItemController(QuotationItemRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateQuotationItem(CreateQuotationItemDTO create)
        {
            try
            {
                var model = mapper.Map<QuotationItem>(create);
                if (repo.CreateQuotationItem(model))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("quotation/{id}")]
        public ActionResult<IEnumerable<ReadQuotationItemDTO>> GetQuotationItemsByQuotationID(int id)
        {
            try
            {
                var QuotationItems = repo.GetQuotationItemsByQuotationID(id);
                return Ok(mapper.Map<IEnumerable<ReadQuotationItemDTO>>(QuotationItems));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ReadQuotationItemDTO> GetQuotationItemByID(int id)
        {
            try
            {
                var QuotationItem = repo.GetQuotationItemByID(id);
                if (QuotationItem != null)
                    return Ok(mapper.Map<ReadQuotationItemDTO>(QuotationItem));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult UpdateQuotationItem
            (CreateQuotationItemDTO create, int id)
        {
            try
            {
                var model = mapper.Map<QuotationItem>(create);
                model.Id = id;
                if (repo.UpdateQuotationItem(model))
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
        public ActionResult DeleteQuotationItem(int id)
        {
            try
            {
                var model = repo.GetQuotationItemByID(id);
                if (model != null)
                {
                    repo.DeleteQuotationItem(model);
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
        public ActionResult<IEnumerable<ReadQuotationItemDTO>> GetQuotationItems()
        {
            try
            {
                var QuotationItems = repo.GetQuotationItems();
                return Ok(mapper.Map<IEnumerable<ReadQuotationItemDTO>>(QuotationItems));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

     
    }
}
