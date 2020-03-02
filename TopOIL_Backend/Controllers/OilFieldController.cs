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
        public async Task<IActionResult> Get([FromQuery(Name = "page")] string page, [FromQuery(Name = "searchObject")] OilFieldSearch searchObject = null) //
        {
            string selectedPage = page;
            if (string.IsNullOrEmpty(page))
            {
                selectedPage = "1";
            }

            IActionResult result = BadRequest();
            try
            {
                PaginatedList<OilField> oilField;

                if (searchObject != null)
                {
                    oilField = await PaginatedList<OilField>.CreateAsync(_context.OilFields,
                        Convert.ToInt32(selectedPage),
                        pageSize);
                }
                else
                {
                    oilField = await PaginatedList<OilField>.CreateAsync(_context.OilFields
                        .Where(of => of.ID.ToString().Contains(searchObject.ID.ToString()) || 
                               of.Name.Contains(searchObject.Name) ||
                               of.Location.Contains(searchObject.Location) ||
                               of.NumOfEmployees.ToString().Contains(searchObject.NumOfEmployees.ToString()) ||
                               of.NumOfPumpjacks.ToString().Contains(searchObject.NumOfPumpjacks.ToString()) ||
                               of.Production.ToString().Contains(searchObject.Production.ToString())),
                        Convert.ToInt32(selectedPage),
                        pageSize);
                }

                Tuple<List<OilField>, int, int> values = new Tuple<List<OilField>, int, int>(oilField, 
                    oilField.TotalPages,
                    oilField.PageIndex);
                result = Ok(values);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            IActionResult result = BadRequest();
            try
            { // TODO add pages
                OilField oilField = _context.OilFields.Find(id);
                if (oilField != null)
                    result = Ok(oilField);
                else
                    return NotFound();

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
    public class OilFieldSearch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public int Production { get; set; }
        public int NumOfPumpjacks { get; set; }
        public string Location { get; set; }
    }
}
