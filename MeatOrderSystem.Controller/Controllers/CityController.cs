using MeatOrderSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeatOrderSystem.Controller.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _service;

    public CityController(ICityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving cities.", details = ex.Message });
        }
    }

    [HttpGet("state/{stateId}")]
    public async Task<IActionResult> GetByState(int stateId)
    {
        try
        {
            var cities = await _service.GetByStateIdAsync(stateId);
            return Ok(cities);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving cities by state.", details = ex.Message });
        }
    }
}
