using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MeatOriginController : ControllerBase
{
    private readonly IMeatOriginService _service;

    public MeatOriginController(IMeatOriginService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
}
