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
    public class QuoteRequestController : ControllerBase
    {
        private readonly QuoteRequestRepo repo;
        private readonly IMapper mapper;

        public QuoteRequestController(QuoteRequestRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateQuoteRequest(CreateQuoteRequestDTO create)
        {
            try
            {
                var model = mapper.Map<QuoteRequest>(create);
                if (repo.CreateQuoteRequest(model))
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
        public ActionResult<ReadQuoteRequestDTO> GetQuoteRequestByID(int id)
        {
            try
            {
                var QuoteRequest = repo.GetQuoteRequestByID(id);
                if (QuoteRequest != null)
                    return Ok(mapper.Map<ReadQuoteRequestDTO>(QuoteRequest));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get quote requests by supplier id
        [HttpGet("supplier/{id}")]
        public ActionResult<IEnumerable<ReadQuoteRequestDTO>> GetQuoteRequestsBySupplierID(int id)
        {
            try
            {
                var QuoteRequests = repo.GetQuoteRequestsBySupplierID(id);
                return Ok(mapper.Map<IEnumerable<ReadQuoteRequestDTO>>(QuoteRequests));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateQuoteRequest
            (CreateQuoteRequestDTO create, int id)
        {
            try
            {
                var model = mapper.Map<QuoteRequest>(create);
                model.Id = id;
                if (repo.UpdateQuoteRequest(model))
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
        public ActionResult DeleteQuoteRequest(int id)
        {
            try
            {
                var model = repo.GetQuoteRequestByID(id);
                if (model != null)
                {
                    repo.DeleteQuoteRequest(model);
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
        public ActionResult<IEnumerable<ReadQuoteRequestDTO>> GetQuoteRequests()
        {
            try
            {
                var Inventories = repo.GetQuoteRequests();
                return Ok(mapper.Map<IEnumerable<ReadQuoteRequestDTO>>(Inventories));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    
    }
}
