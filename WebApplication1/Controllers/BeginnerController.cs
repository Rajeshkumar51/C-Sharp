using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeginnerController : ControllerBase
    {
        private static readonly List<string> Foods = new List<string> { "Pizza", "Burger", "Dosa", "Pasta" };

        [HttpGet("menu")]
        public IActionResult GetMenu()
        {
            return Ok(Foods);
        }

        [HttpPost("menu/add")]
        public IActionResult AddFood([FromQuery] string item)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                return BadRequest("Food item cannot be empty.");
            }

            Foods.Add(item);
            return Ok(new { message = $"{item} added to the menu.", menu = Foods });
        }
        [HttpDelete("menu/delete")]
public IActionResult DeleteFood(string item)
{
    var itemIndex = Foods.FindIndex(f => f.Equals(item, StringComparison.OrdinalIgnoreCase));
    
    if (itemIndex == -1)
        return NotFound($"{item} not found in the menu.");

    Foods.RemoveAt(itemIndex);
    return Ok($"{item} has been removed from the menu.");
}

    }
}
