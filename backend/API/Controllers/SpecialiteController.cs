using System;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialiteController : ControllerBase
    {
        private readonly IRepository<Specialite> _specialiteRepository;

        public SpecialiteController(IRepository<Specialite> specialiteRepository)
        {
            _specialiteRepository = specialiteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _specialiteRepository.GetAll();
            return Ok(books);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var book = await _specialiteRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Specialite specialite)
        {
            if (specialite == null)
            {
                return BadRequest("Specialite is null.");
            }
            await _specialiteRepository.Create(specialite);
            return CreatedAtAction(nameof(GetById), new { id = specialite.Id }, specialite);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Specialite specialite)
        {
            if (specialite == null)
            {
                return BadRequest("Specialite is null.");
            }

            var existingSpecialite = await _specialiteRepository.GetById(id);
            if (existingSpecialite == null)
            {
                return NotFound();
            }

            specialite.Id = id; 
            await _specialiteRepository.Update(id, specialite);

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] string id)
        {
            var existingSpecialite = await _specialiteRepository.GetById(id);
            if (existingSpecialite == null)
            {
                return NotFound();
            }

            await _specialiteRepository.Delete(id);

            return NoContent();
        }
    }
}

