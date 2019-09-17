using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TopOIL_Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OilFieldController : ControllerBase
    {
        private int pageSize = 2;

        private readonly Context _context;

        public OilFieldController(Context context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery(Name = "page")] string page)
        {
            IActionResult result = BadRequest();
            try
            {
                var oilField = await _context.OilFields.FindAsync(id);
                _context.Remove(oilField);
                result = Ok(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPTION: {e.Message}");
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            IActionResult result = BadRequest();
            return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            IActionResult result = BadRequest();
            try
            {
                var oilField = await _context.OilFields.FindAsync(id);
                _context.Remove(oilField);
                result = Ok(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPTION: {e.Message}");
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IActionResult result = BadRequest();
            try
            {
                var oilField = await _context.OilFields.FindAsync(id);
                _context.Remove(oilField);
                result = Ok(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPTION: {e.Message}");
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }
    }
}
