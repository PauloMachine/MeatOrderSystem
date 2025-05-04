using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeatOrderSystem.Controller.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? buyerId, [FromQuery] DateTime? date)
    {
        try
        {
            var orders = await _service.GetAllAsync(buyerId, date);
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Failed to retrieve orders.", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var order = await _service.GetByIdAsync(id);
            return order is null
                ? NotFound(new { message = $"Order with ID {id} not found." })
                : Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving the order.", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating the order.", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateOrderDto dto)
    {
        try
        {
            var success = await _service.UpdateAsync(id, dto);
            return success
                ? NoContent()
                : NotFound(new { message = $"Order with ID {id} not found." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error updating the order.", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var success = await _service.DeleteAsync(id);
            return success
                ? NoContent()
                : NotFound(new { message = $"Order with ID {id} not found." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error deleting the order.", error = ex.Message });
        }
    }
}
