using Microsoft.AspNetCore.Mvc;
using on_the_sky.core.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace on_the_sky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly ItravelService _travelservice;


        public TravelsController(ItravelService travelservice)
        {
            _travelservice = travelservice;
        }

        // GET: api/<TravelsController>
        [HttpGet]
        public ActionResult<Travels> Get()
        {
            return Ok( _travelservice.GetAll());
        }

        // GET api/<TravelsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var travel = _travelservice.GetById(id);
            if (travel != null)
            {
                return Ok(travel);
            }
            return NotFound();
        }

       
        // POST api/<TravelsController>
        [HttpPost]
        public ActionResult Post([FromBody] Travels value)
        {
            var travel = _travelservice.GetById(value.passengerid);
            if (travel != null)
            {
                return Conflict();
            }
            _travelservice.ADD(value);
            return Ok();
        }
    

        // PUT api/<TravelsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Travels value)
        {
        var travel = _travelservice.Put(id, value);
        if (travel != null)
        {
            return Ok();
        }
        return NotFound();                                    // עדכון אובייקט
        }

        // DELETE api/<TravelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var travel = _travelservice.Delete(id);
            if (travel != null)
            {
                return Ok();
            }
            return NotFound();                         //מחיקת אובייקט
        }
    }
}
