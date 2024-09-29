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
    public class QuoteRequestItemController : ControllerBase
    {
        private readonly QuoteRequestItemRepo repo;
        private readonly IMapper mapper;

        public QuoteRequestItemController(QuoteRequestItemRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateQuoteRequestItem(CreateQuoteRequestItemDTO create)
        {
            try
            {
                var model = mapper.Map<QuoteRequestItem>(create);
                if (repo.CreateQuoteRequestItem(model))
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
        public ActionResult<ReadQuoteRequestItemDTO> GetQuoteRequestItem(int id)
        {
            try
            {
                var QuoteRequestItem = repo.GetQuoteRequestItemByID(id);
                if (QuoteRequestItem != null)
                    return Ok(mapper.Map<ReadQuoteRequestItemDTO>(QuoteRequestItem));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("quote/{id}")]
        public ActionResult<IEnumerable<ReadQuoteRequestItemDTO>> GetQuoteRequestItemsByQuoteRequestID(int id)
        {
            try
            {
                var QuoteRequestItems = repo.GetQuoteRequestItemsByQuoteRequestID(id);
                return Ok(mapper.Map<IEnumerable<ReadQuoteRequestItemDTO>>(QuoteRequestItems));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateQuoteRequestItem
            (CreateQuoteRequestItemDTO create, int id)
        {
            try
            {
                var model = mapper.Map<QuoteRequestItem>(create);
                model.Id = id;
                if (repo.UpdateQuoteRequestItem(model))
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
        public ActionResult DeleteQuoteRequestItem(int id)
        {
            try
            {
                var model = repo.GetQuoteRequestItemByID(id);
                if (model != null)
                {
                    repo.DeleteQuoteRequestItem(model);
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
        public ActionResult<IEnumerable<ReadQuoteRequestItemDTO>> GetQuoteRequestItems()
        {
            try
            {
                var QuoteRequestItems = repo.GetQuoteRequestItems();
                return Ok(mapper.Map<IEnumerable<ReadQuoteRequestItemDTO>>(QuoteRequestItems));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
