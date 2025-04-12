using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new[] { "Product 1", "Product 2" });
}
