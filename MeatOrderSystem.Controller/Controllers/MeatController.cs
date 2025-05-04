using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeatOrderSystem.Controller.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeatController : ControllerBase
{
    private readonly IMeatService _service;

    public MeatController(IMeatService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var meats = await _service.GetAllAsync();
            return Ok(meats);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving meats.", details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var meat = await _service.GetByIdAsync(id);
            return meat is null ? NotFound() : Ok(meat);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving the meat.", details = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMeatDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var result = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while creating the meat.", details = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateMeatDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated is null ? NotFound() : NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while updating the meat.", details = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var (success, error) = await _service.DeleteAsync(id);
            if (!success)
                return Conflict(new { message = error });

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while deleting the meat.", details = ex.Message });
        }
    }
}
