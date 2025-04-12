using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new[] { "Order 1", "Order 2" });
}