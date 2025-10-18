using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyFeedback.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyReadDto>> Get(int id)
        {
            var item = await _companyService.GetAync(id);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyReadDto>>> GetAll()
        {
            var items = await _companyService.GetAllAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyReadDto>> Create([FromBody] CompanyCreateDto companyDto)
        {
            var createdItem = await _companyService.CreateAsync(companyDto);

            return CreatedAtAction(nameof(Get), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyReadDto>> Update(int id, [FromBody] CompanyUpdateDto companyDto)
        {
            if (id != companyDto.Id)
                return BadRequest("ID mismatch");

            try
            {
                var updatedItem = await _companyService.UpdateAsync(companyDto);
                return Ok(updatedItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _companyService.DeleteAsync(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
