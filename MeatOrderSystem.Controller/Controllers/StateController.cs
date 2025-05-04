using MeatOrderSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StateController : ControllerBase
{
    private readonly IStateService _service;

    public StateController(IStateService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var states = await _service.GetAllAsync();
            return Ok(states);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving states.", error = ex.Message });
        }
    }
}
