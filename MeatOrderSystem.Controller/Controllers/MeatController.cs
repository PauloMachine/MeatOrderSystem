
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
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var meat = await _service.GetByIdAsync(id);
        return meat is null ? NotFound() : Ok(meat);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMeatDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var result = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateMeatDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var (success, error) = await _service.DeleteAsync(id);

        if (!success)
                return Conflict(new { message = error });

        return NoContent();
    }
}

