using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopOIL_Backend.Models;

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
        public async Task<IActionResult> Get([FromQuery(Name = "page")] string page) //
        {
            string selectedPage = page;
            if (page == null)
            {
                selectedPage = "1";
            }

            IActionResult result = BadRequest();
            try
            { // TODO add pages
                var oilField = await PaginatedList<OilField>.CreateAsync(_context.OilFields, Convert.ToInt32(selectedPage), pageSize);
                Tuple<List<OilField>, int> ret = new Tuple<List<OilField>, int>(oilField, oilField.TotalPages);
                result = Ok(ret);
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
        public IActionResult Get(int id)
        {
            IActionResult result = BadRequest();
            try
            { // TODO add pages
                var oilField = _context.OilFields.Find(id);
                result = Ok(oilField);
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPTION: {e.Message}");
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] OilField value)
        {
            IActionResult result = BadRequest();
            try
            {

                var oilField = _context.OilFields.Add(value);
                _context.SaveChanges();
                result = Ok(oilField.Entity);
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPTION: {e.Message}");
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OilField value)
        {
            IActionResult result = BadRequest();
            try
            {
                var oilField = _context.OilFields.Update(value);
                _context.SaveChanges();
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
        public IActionResult Delete(int id)
        {
            IActionResult result = BadRequest();
            try
            {
                var oilField = _context.OilFields.Find(id);
                _context.Remove(oilField);
                _context.SaveChanges();
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
