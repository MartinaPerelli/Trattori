using Microsoft.AspNetCore.Mvc;
using Trattori.Models;
using Trattori.Services;

namespace Trattori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TractorsController : ControllerBase
    {
        ITractorService _tractorService;

        public TractorsController(ITractorService tractorService )
        {
            _tractorService = tractorService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PostTractorModel tractor)
        {
            var tractorAdded = _tractorService.Create(tractor);
            return StatusCode(201,tractorAdded);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Tractor tractor;
            try
            {
                 tractor = _tractorService.GetDetails(id);
            }
            catch(ArgumentException exc)
            {
                return BadRequest(exc.Message);
            }
            return StatusCode(200,tractor);
        }

        [HttpGet("/filteredby/{filter}")]
        public IActionResult GetAllByFilter(int filter)
        {
            return Ok(_tractorService.GetAllTractorsByFilter(filter));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PostTractorModel newTractor)
        {
            Tractor tractorToUpdate;
            try
            {
                tractorToUpdate = _tractorService.Update(id,newTractor);
            }
            catch (ArgumentException exc)
            {
                return BadRequest(exc.Message);
            }

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            try
            {
                _tractorService.Delete(id);
            }
            catch(ArgumentException exc)
            {
                return BadRequest(exc.Message);
            }

            return Ok();
        }
    }
}
