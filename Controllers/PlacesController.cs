using Microsoft.AspNetCore.Mvc;
using on_the_sky.core.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace on_the_sky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IplaceService _Placeservice ;
       

        public PlacesController(IplaceService Placeservice)
        {
            _Placeservice = Placeservice;
        }



        // GET: api/<TravelsController>
        [HttpGet]
        public ActionResult<Places> Get()
        {

            return Ok(_Placeservice.GetAll());
         
        }

        // GET api/<TravelsController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var place = _Placeservice.GetById(id);
            if (place != null)
            {
                return Ok(place);
            }
            return NotFound();
        }


        // POST api/<TravelsController>
        [HttpPost]
        public ActionResult Post([FromBody] Places value)
        {
            var place = _Placeservice.GetById(value.countryid);
            if (place != null)
            {
                return Conflict();
            }
            _Placeservice.ADD(value);
            return Ok();
        }

        // PUT api/<TravelsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Places value)
        {
            var place = _Placeservice.Put(id, value);
            if (place != null)
            {
                return Ok();
            }
            return NotFound();                                 // עדכון אובייקט
        }

        // DELETE api/<TravelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var place = _Placeservice.Delete(id);
            if (place != null)
            {
                return Ok();
            }
            return NotFound();
            //מחיקת אובייקט
        }
    }
}
