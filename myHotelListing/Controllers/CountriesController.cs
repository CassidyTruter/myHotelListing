using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myHotelListing.API.Data;
using myHotelListing.Data;
using myHotelListing.Models.Country;

namespace myHotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase // inherit from ControllerBase
    {
        /* Task - A task in C# is used to implement Task-based Asynchronous Programming. The Task
         *        object is typically executed asynchronously on a thread pool thread rather than
         *        synchronously on the main thread of the application.
         *
         * async - Signals to the compiler that this method contains an await statement; it
         *         contains asynchronous operations.
         *         
         * await - The await keyword provides a non-blocking way to start a task, then continue
         *         execution when that task completes.
         *         
         * ActionResult - An action is capable of returning a specific data type 
         *                (see WeatherForecastController action).  When multiple return types are
         *                possible, it's common to return ActionResult, IActionResult or 
         *                ActionResult<T>, where T represents the data type to be returned.
         */

        // Inject Db context into controller (next 4 lines). Can be injected in other places too.
        private readonly myHotelListingDbContext _context;
        public CountriesController(myHotelListingDbContext context)
        {
            _context = context; // initialise copy of db context
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // good
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {
            var country = new Country
            {
                Name = createCountry.Name,
                ShortName = createCountry.ShortName,
            };
            _context.Countries.Add(country); // add country to Countries table of database
            await _context.SaveChangesAsync(); // execute change

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent(); // good
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
