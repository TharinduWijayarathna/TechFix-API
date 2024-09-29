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
    public class QuotationController : ControllerBase
    {
        private readonly QuotationRepo repo;
        private readonly IMapper mapper;

        public QuotationController(QuotationRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
        [HttpPost]
        public ActionResult CreateQuotation(CreateQuotationDTO create)
        {
            try
            {
                var model = mapper.Map<Quotation>(create);
                if (repo.CreateQuotation(model))
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
        public ActionResult<ReadQuotationDTO> GetQuotationByID(int id)
        {
            try
            {
                var Quotation = repo.GetQuotationByID(id);
                if (Quotation != null)
                    return Ok(mapper.Map<ReadQuotationDTO>(Quotation));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateQuotation
            (CreateQuotationDTO create, int id)
        {
            try
            {
                var model = mapper.Map<Quotation>(create);
                model.Id = id;
                if (repo.UpdateQuotation(model))
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
        public ActionResult DeleteQuotation(int id)
        {
            try
            {
                var model = repo.GetQuotationByID(id);
                if (model != null)
                {
                    repo.DeleteQuotation(model);
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
        public ActionResult<IEnumerable<ReadQuotationDTO>> GetQuotations()
        {
            try
            {
                var Quotations = repo.GetQuotations();
                return Ok(mapper.Map<IEnumerable<ReadQuotationDTO>>(Quotations));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
