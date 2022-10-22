using Microsoft.AspNetCore.Mvc;
using Trattori.Models;
using Trattori.Services;

namespace Trattori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TractorsController : ControllerBase
    {
        ITractorOnFileService _tractorService;

        public TractorsController(ITractorOnFileService tractorService )
        {
            _tractorService = tractorService;
        }

        //[HttpPost]
        //public IActionResult Add([FromBody] PostTractorModel tractor)
        //{
        //    var tractorAdded = _tractorService.Create(tractor);
        //    return StatusCode(201,tractorAdded);
        //} 
        
        [HttpPost]
        public IActionResult Add([FromBody] PostTractorModel tractor)
        {
            var tractorAdded = _tractorService.AddTractor(tractor);
            return StatusCode(201,tractorAdded);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    Tractor tractor;
        //    try
        //    {
        //         tractor = _tractorService.GetDetails(id);
        //    }
        //    catch(ArgumentException exc)
        //    {
        //        return BadRequest(exc.Message);
        //    }
        //    return StatusCode(200,tractor);
        //}

        //[HttpGet()]
        //public IActionResult GetAllByFilter([FromQuery] TractorQueryModel tractor)
        //{
        //    var filteredList = _tractorService.GetAll(tractor);
        //    return Ok(filteredList);
        //}

        [HttpGet()]
        public IActionResult GetAllByFilter([FromQuery] TractorQueryModel tractor)
        {
            var filteredList = _tractorService.GetAll(tractor);
            return Ok(filteredList);
        }

        //[HttpGet("{idGadget}")]
        //public IActionResult GetByGadget(int idGadget)
        //{
        //    var filteredTractors = _tractorService.GetTractorsByGadgets(idGadget);
        //    return Ok(filteredTractors);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] PostTractorModel newTractor)
        //{
        //    Tractor tractorToUpdate;
        //    try
        //    {
        //        tractorToUpdate = _tractorService.Update(id,newTractor);
        //    }
        //    catch (ArgumentException exc)
        //    {
        //        return BadRequest(exc.Message);
        //    }

        //    return StatusCode(204);
        //}

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PostTractorModel newTractor)
        {
            Tractor tractorToUpdate;
            try
            {
                tractorToUpdate = _tractorService.Update(id,newTractor);
            }
            catch(ArgumentException exc)
            {
                return BadRequest(exc.Message);
            }
            return Created(nameof(GetAllByFilter), tractorToUpdate);
        }


        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{

        //    try
        //    {
        //        _tractorService.Delete(id);
        //    }
        //    catch(ArgumentException exc)
        //    {
        //        return BadRequest(exc.Message);
        //    }

        //    return Ok();
        //}

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
