using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeatOrderSystem.Controller.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuyerController : ControllerBase
{
    private readonly IBuyerService _service;

    public BuyerController(IBuyerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var buyer = await _service.GetByIdAsync(id);
        return buyer is null ? NotFound() : Ok(buyer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBuyerDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateBuyerDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.UpdateAsync(id, dto);
        return result is null ? NotFound() : NoContent();
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
