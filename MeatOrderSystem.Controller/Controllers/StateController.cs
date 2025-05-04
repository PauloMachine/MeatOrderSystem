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
        var states = await _service.GetAllAsync();
        return Ok(states);
    }
}
