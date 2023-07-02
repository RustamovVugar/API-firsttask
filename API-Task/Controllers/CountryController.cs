using API_Task.Data;
using API_Task.DTOs.Country;
using API_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_Task.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
      private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Country? country = await _context.Countries.FirstOrDefaultAsync(m=>m.Id == id);

            if (country == null) return NotFound();

           return Ok(country);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Country> countries = await _context.Countries.ToListAsync();
            return Ok(countries);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Country country = new()
            {
                Name = request.Name,
                Capital = request.Capital,
            };

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody][Required] int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(m=>m.Id == id);

            if (country == null) return NotFound();

            _context.Countries.Remove(country);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            if (country == null) return NotFound();

            _context.Countries.Update(country);

            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
