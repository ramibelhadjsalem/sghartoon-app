using System;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {

        private readonly IRepository<Country> _repository;
        public CountryController(IRepository<Country> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("Specialite is null...");
            }
            await _repository.Create(country);
            return CreatedAtAction(nameof(GetById), new { id = country.Id }, country);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("Country is null.");
            }

            var existingCountry = await _repository.GetById(id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            country.Id = id;
            await _repository.Update(id, country);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] string id)
        {
            var existingCountry = await _repository.GetById(id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);

            return NoContent();
        }
    }
}

