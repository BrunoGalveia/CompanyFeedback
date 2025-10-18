using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyFeedback.API.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackReadDto>> Get(int id)
        {
            var item = await _feedbackService.GetAync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackReadDto>>> GetAll()
        {
            var items = await _feedbackService.GetAllAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<FeedbackReadDto>> Create([FromBody] FeedbackCreateDto feedbackDto)
        {
            var createdItem = await _feedbackService.CreateAsync(feedbackDto);

            return CreatedAtAction(nameof(Get), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FeedbackReadDto>> Update(int id, [FromBody] FeedbackUpdateDto feedbackDto)
        {
            if (id != feedbackDto.Id)
                return BadRequest("ID mismatch");

            try
            {
                var updatedItem = await _feedbackService.UpdateAsync(feedbackDto);
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
                var result = await _feedbackService.DeleteAsync(id);
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
