using Microsoft.AspNetCore.Mvc;
using on_the_sky.core.services;
using on_the_sky.service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace on_the_sky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightservice ;


        public FlightController(IFlightService flightservice)
        {
            _flightservice = flightservice;
        }

        // GET: api/<TravelsController>
        [HttpGet]
        public ActionResult <Flight> Get()
        {
            return Ok( _flightservice.Getlist());
        }

        // GET api/<TravelsController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var fly = _flightservice.GetById(id);
            if (fly != null) { 
                return Ok(fly);
            }
            return NotFound() ;
        }


        // POST api/<TravelsController>
        [HttpPost]
        public ActionResult Post([FromBody] Flight f)
        {
            var fly = _flightservice.GetById(f.flightid);
            if (fly != null)
            {
                return Conflict();
            }
            _flightservice.ADD(f);
            return Ok();
        }

        // PUT api/<TravelsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Flight value)
        {
            var fly = _flightservice.Put(id,value);
            if (fly != null)
            {
                return Ok();
            }
            return NotFound();                        // עדכון אובייקט
        }

        // DELETE api/<TravelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var fly= _flightservice.Delete(id);
            if (fly != null)
            {
                return Ok();
            }
            return NotFound();

        }
}
}
