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
        try
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "An error occurred while retrieving meat origins.",
                details = ex.Message
            });
        }
    }
}
