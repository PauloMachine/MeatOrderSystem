using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Model.Entities;
using MeatOrderSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeatOrderSystem.Controller.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;
    private readonly ICurrencyConverterService _converter;

    public OrderController(IOrderService service, ICurrencyConverterService converter)
    {
        _service = service;
        _converter = converter;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? buyerId, [FromQuery] DateTime? date)
        => Ok(await _service.GetAllAsync(buyerId, date));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _service.GetByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var created = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateOrderDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        
        if (!success)
            return NotFound(new { message = "Order not found for deletion." });

        return NoContent();
    }
}
