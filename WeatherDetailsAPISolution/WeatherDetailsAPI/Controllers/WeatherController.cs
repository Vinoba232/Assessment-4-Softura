using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherDetailsAPI.Models;

namespace WeatherDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeatherController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/Weather
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeather()
        {
            return await _context.Weather.ToListAsync();
        }

        // GET: api/Weather/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weather>> GetWeather(string id)
        {
            var weather = await _context.Weather.FindAsync(id);

            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // PUT: api/Weather/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(string id, Weather weather)
        {
            if (id != weather.City)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weather
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weather>> PostWeather(Weather weather)
        {
            _context.Weather.Add(weather);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeatherExists(weather.City))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWeather", new { id = weather.City }, weather);
        }

        // DELETE: api/Weather/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(string id)
        {
            var weather = await _context.Weather.FindAsync(id);
            if (weather == null)
            {
                return NotFound();
            }

            _context.Weather.Remove(weather);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherExists(string id)
        {
            return _context.Weather.Any(e => e.City == id);
        }
    }
}
